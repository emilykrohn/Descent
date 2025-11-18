using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int MAX_HEALTH = 100;
    [SerializeField] WorldSpaceHealthBar healthBar;

    private void Start()
    {   
        health = MAX_HEALTH;
        // Initialize the health bar at the start
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, MAX_HEALTH);
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
            healthBar.UpdateHealthBar(health, MAX_HEALTH);
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

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH; //checks if exceeding health limit

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
        // update health bar
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, MAX_HEALTH);
        }
    }

    private void Die()
    {
        Debug.Log("Destroyed!"); //prints message
        Destroy(gameObject); //removes game object from scene
    }
}
