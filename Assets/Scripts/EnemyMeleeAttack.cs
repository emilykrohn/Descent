//Requirement #9
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private Transform player;
    [SerializeField] private string playerTag = "Player";

    [Header("Ranges & Timing")]
    [SerializeField] private float detectRadius = 6f;     // detection radius
    [SerializeField] private float meleeRange = 1.4f;     // range in order to attack
    [SerializeField] private float attackActiveTime = 0.25f; // How long attackArea is enabled (same as playerAttack rn will change later)
    [SerializeField] private float attackCooldown = 1.0f; // Time between attacks
    [SerializeField] private float windupTime = 0.1f;     // Optional short delay before enabling the hitbox

    [Header("Hitbox")]
    [SerializeField] private GameObject attackArea = default; // Enable/disable to deal damage

    [Header("Optional Animation")]
    [SerializeField] private Animator animator;            // Set a Trigger on swing if/when we use animations
    [SerializeField] private string attackTriggerName = "Attack";

    // internal state
    private bool attacking = false;   // whether the hitbox is currently active
    private float activeTimer = 0f;   // how long the hitbox has been on
    private float lastAttackTime = -999f; //cooldown check

    private void Start()
    {
        // Auto-wire the player if not assigned
        if (player == null)
        {
            var go = GameObject.FindGameObjectWithTag(playerTag);
            if (go) player = go.transform;
        }

        // makes sure the hitbox starts off
        if (attackArea != null) attackArea.SetActive(false);
    }

    private void Update()
    {
        if (player == null || attackArea == null) return; // if no player or hitbox

        float dist = Vector2.Distance(transform.position, player.position);  //measures distance to player

        // If currently attacking, keep timing and turn off when done
        if (attacking)
        {
            activeTimer += Time.deltaTime;
            if (activeTimer >= attackActiveTime)
            {
                // End attack window
                attacking = false;
                activeTimer = 0f;
                attackArea.SetActive(false);
            }
            return; // Don’t try to start new attacks while one is active
        }

        // Not currently attacking — check if we should attack
        if (dist <= detectRadius && dist <= meleeRange)
        {
            // Cooldown
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // Begin attack sequence
                lastAttackTime = Time.time;

                // use animation trigger if provided
                if (animator != null && !string.IsNullOrEmpty(attackTriggerName))
                    animator.SetTrigger(attackTriggerName);

                // Optionally delay before enabling the hitbox (windup)
                if (windupTime > 0f)
                    Invoke(nameof(EnableHitbox), windupTime);
                else
                    EnableHitbox();
            }
        }
    }

    private void EnableHitbox()
    {
        attacking = true;
        activeTimer = 0f;
        attackArea.SetActive(true); // AttackArea.cs will apply damage to anything with Health
    }
}
