using UnityEngine;

public class EnemyArrowScript : MonoBehaviour
{
    // 9. When the user's character gets in range of an enemy, they will attack.

    // Script for Enemy's Arrows

    private GameObject user; // User set to private to reference it in Start() function
    private Rigidbody2D rb; // Reference to RigidBody 2D
    public float speed; // To control speed of the arrow in editor

    private float timer; // Used for game logic
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtains RigidBody 2D
        user = GameObject.FindGameObjectWithTag("Player"); // Used to reference target of enemy's arrow which is "Player"

        Vector3 direction = user.transform.position - transform.position; // Creates a direction directly towards the user
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        // Direction of arrow stays the same with a controlled speed whenever it goes towards the user


        // Gives and angle converted from radians to degrees
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        
        
        // Makes arrow shoot at a correct angle towards the Player from z-axis
        transform.rotation = Quaternion.Euler(0, 0, rotation + -90); 
        // -90 degrees since it makes arrow prefab visually and correctly point towards the user
    }

   
    void Update()
    {
        timer += Time.deltaTime; // Allows timer to increase time in seconds

        if (timer > 10) // Provides game logic that if arrow stays in game scene after 10 sec., it will be destroyed
        {
            Destroy(gameObject); // Destroys arrow at a certain time
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) // When the arrow collides with the user's playable character, the arrow disappears
    {
        if (other.gameObject.CompareTag("Player")) // If arrow collides with the "Player"
        {
            Destroy(gameObject); // Destroys the arrow once arrow meets the user
        }
    }
}
