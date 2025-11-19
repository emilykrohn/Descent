using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3; // using 3 as an example

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Keep the attack area positioned at the player's position
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) //detects whether or not there are colliders inside its trigger area
    {
        if(collider.gameObject.tag == "Enemy") //if they have a health component attached to them
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage); // they will take damage
            Debug.Log("Enemy hit");
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
