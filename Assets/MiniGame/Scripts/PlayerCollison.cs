using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that handles collision between main player and enemies
/// </summary>
public class PlayerCollison : MonoBehaviour {

    /// <summary>
    /// reference to <see cref="PlayerController"/>
    /// </summary>
    public PlayerController movement;

    /// <summary>
    /// Checks if its a enemy that has collided, disables the movement in playercontroller class,
    /// then calls <see cref="GameManager.GameOver"/>
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag == "Enemy")
        {
            movement.enabled = false;                      
            FindObjectOfType<GameManager>().GameOver();     
        }
    }
} 
