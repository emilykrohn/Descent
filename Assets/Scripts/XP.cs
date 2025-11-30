using UnityEngine;

public class XP : MonoBehaviour
{
    int xp = 10;
    XpBar xpBar;
    private Vector3 direction;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 3f;
    private PlayerMovement player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
        xpBar = FindFirstObjectByType<XpBar>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetXP(int newXP)
    {
        xp = newXP;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player triggers the xp, increase their xp and update the xp bar
        if (collision.gameObject.tag == "Player")
        {
            // Increase the player's xp
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            playerStats.SetXP(playerStats.GetXP() + xp);
            xpBar.UpdateXp(xp);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Move towards the player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x, direction.y) * speed;
    }
}
