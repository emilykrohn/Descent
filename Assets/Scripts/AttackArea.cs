using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3; // using 3 as an example

    private GameObject player;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        if (playerStats != null)
        {
            damage = playerStats.GetAttack();
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Keep the attack area positioned at the player's position
        if (player != null)
        {
            transform.position = player.transform.position;
        }
        
        // Attack area rotates to face the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnTriggerEnter2D(Collider2D collider) //detects whether or not there are colliders inside its trigger area
    {
        if(collider.gameObject.tag == "Enemy") //if they have a health component attached to them
        {
            Health health = collider.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage); // they will take damage
            }
        }
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public int GetDamage()
    {
        return damage;
    }
}
