using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] WorldSpaceHealthBar healthBar;
    [SerializeField] HealthBar playerHealthBar;
    [SerializeField] GameObject xp;

    private void Start()
    {
        health = maxHealth;
        // Initialize the health bar at the start
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }
    public void Damage(int amount) //reduces object's health by a given amount
    {
        if(amount < 0) //makes damage value not negative
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount; //subtracts damage amount from health

        // update health bar
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }

        if (playerHealthBar != null)
        {
            playerHealthBar.UpdateHealth(-amount);
        }

        if(health <= 0) //if health drops below 0
        {
            Die(); //calls Die method
        }

    }

    public void Heal(int amount) //restores object's health by given amount
    {
        if (amount < 0) //not negative
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > maxHealth; //checks if exceeding health limit

        if (wouldBeOverMaxHealth)
        {
            this.health = maxHealth;
        }
        else
        {
            this.health += amount;
        }
        // update health bar
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }
    }

    private void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();
            EnemySpawner enemySpawner = FindFirstObjectByType<EnemySpawner>();
            playerStats.SetCurrentEnemiesDefeated(playerStats.GetCurrentEnemiesDefeated() + 1);
            if (playerStats.GetCurrentEnemiesDefeated() == enemySpawner.GetTotalEnemiesSpawned())
            {
                playerStats.SetCurrentEnemiesDefeated(0);
                playerStats.SetCurrentFloorNumber(playerStats.GetCurrentFloorNumber() + 1);
                RoomManager roomManager = FindFirstObjectByType<RoomManager>();
                roomManager.LoadNewRoom();
            }
            Instantiate(xp, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); //removes game object from scene
    }
}
