using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Default speed of Enemy
    Rigidbody2D rigidbody; // Sets a Rigidbody for physics (Gravity = 0)
    Transform victim; // Sets target variable whenever Player moves
    Vector2 movDirect; // When enemy moves direction

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Allows for 2D physics to occur
    }

    void Start()
    {
        victim = GameObject.Find("Player").transform; // Confirms Player as the Enemy's target when Player moves everytime
    }

    void Update()
    {
        if (victim)
        {
            Vector3 direct = (victim.position - transform.position).normalized; // Initialize Vector3 direction
            movDirect = direct; // To make Enemy face the target (Player) while moving


        }
    }


    private void FixedUpdate()
    {
        if (victim)
        {
            rigidbody.linearVelocity = new Vector2(movDirect.x, movDirect.y) * speed; // Initializes velocity of Enemy when chasing Player

        }
    }

}
