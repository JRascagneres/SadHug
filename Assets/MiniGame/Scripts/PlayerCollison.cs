using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour {

    //reference to playercontroller script
    public PlayerController movement;

    //Tests to see if an object has triggered the collider on main player
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if its a enemy that has collided
         if(other.tag == "Enemy")
        {
            movement.enabled = false;                       //Disables the movement in playercontroller class
            FindObjectOfType<GameManager>().GameOver();     //Calls the game over function in game manager class
        }
    }
} 
