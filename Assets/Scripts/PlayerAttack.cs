using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default; //the area where the attack happens

    private bool attacking = false; //tracks whether tha player is currently attacking

    private float timeToAttack = 0.25f; //duration of the attack
    private float timer = 0f; //timer to keep track how long the attack has been active

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //checks if space bar is pressed to trigger an attack
        {
            Attack(); //calls attack method
        }

        if(attacking)
        {
            timer += Time.deltaTime; //increases the timer by the time passed since the last frame

            if(timer >= timeToAttack) //this checks to see if the duration of the attack reached the set time limit
            {
                timer = 0; //resets timer
                attacking = false; //ends attacking state
                attackArea.SetActive(attacking); //deactivates the attack area
            }
        }
    }

    private void Attack() //sets attack method to true
    {
        attacking = true;
        attackArea.SetActive(attacking); //activates the attack area
    }
}