using UnityEngine;

public class Enemy_LongRangeAttack : MonoBehaviour
{
    // 9. When the user's character gets in range of an enemy, they will atack.


    // Long Range Attack for Enemy Shooting Arrows
    public GameObject arrow; // Arrow game object
    public Transform arrowPos; // Arrow position 

    private float timer; // Used to control the frequency of how often the arrow spawns into the game scene

    private GameObject user; // To identify "Player" GameObject as the target for enemy's attack

    void Start()
    {
        user = GameObject.FindGameObjectWithTag("Player"); // Finds Player when shooting in long range
    }


    void Update()
    {
        // In every frame, the distance between the enemy and the user will detect when enemy will shoot
        float distance = Vector2.Distance(transform.position, user.transform.position); 
        Debug.Log(distance); // In the editor, the distance will be known at all times

        if (distance < 5) // If player is within a range less than 5, the Enemy will shoot
        {
            timer += Time.deltaTime; // Timer will go up in seconds

            if (timer > 2) // If timer runs up to 2 sec., then sets timer back to 0 of how often enemy shoots
            {
                timer = 0;
                repShoot();
            }
        }

    
    }
    
    void repShoot() // This function instantiates an arrow according to its position and angle
    {
        Instantiate(arrow, arrowPos.position, Quaternion.identity); // Represents arrow by position and angle
    }
}
