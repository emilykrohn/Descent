using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3; // using 3 as an example

    private void OnTriggerEnter2D(Collider2D collider) //detects whether or not there are colliders inside its trigger area
    {
        if(collider.GetComponent<Health>() != null) //if they have a health component attached to them
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage); // they will take damage
        }
    }
}
