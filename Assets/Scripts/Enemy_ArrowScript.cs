using UnityEngine;

public class EnemyArrowScript : MonoBehaviour
{
    // 9. When the user's character gets in range of an enemy, they will attack.

    // Script for Enemy's Arrows

    [SerializeField] private float speed = 8f; // To control speed of the arrow in editor
    [SerializeField] private int playerDmg = 10; // The amount of damage Player takes per hit
    [SerializeField] private float lifeArrow = 10f; // The amount of time an arrow's life is within game

    private GameObject user; // User set to private to reference it in Start() function
    private Rigidbody2D rb; // Reference to RigidBody 2D

    private float timer; // Used for game logic
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtains RigidBody 2D
        user = GameObject.FindGameObjectWithTag("Player"); // Used to reference target of enemy's arrow which is "Player"

        if(user != null)
        {

        Vector3 direction = user.transform.position - transform.position; // Creates a direction directly towards the user
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        // Direction of arrow stays the same with a controlled speed whenever it goes towards the user


        // Gives and angle converted from radians to degrees
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        
        
        // Makes arrow shoot at a correct angle towards the Player from z-axis
        transform.rotation = Quaternion.Euler(0, 0, rotation + -90); 
        // -90 degrees since it makes arrow prefab visually and correctly point towards the user
        }
    
    }

   
    void Update()
    {
        timer += Time.deltaTime; // Allows timer to increase time in seconds

        if (timer > lifeArrow) // Provides game logic that if arrow stays in game scene after 10 sec., it will be destroyed
        {
            Destroy(gameObject); // Destroys arrow at a certain time
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) // When the arrow collides with the user's playable character, the arrow disappears
    {
        // Triggers whenever the Player is hit with damage
        if (other.gameObject.CompareTag("Player")) // If arrow collides with the "Player"
        {
            // Modifies the player's health through player's Health component
            Health healthHP = other.GetComponent<Health>(); // This damages the player's health by referencing through Health component
            if (healthHP != null) // Checks if there is still leftover health
            {
                healthHP.Damage(playerDmg); // Deals damage to player
            }
            Destroy(gameObject); // Destroys the arrow once arrow meets the user
        }
    }
}
