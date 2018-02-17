using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollison : MonoBehaviour {

    public PlayerController movement;

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag == "Enemy")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
} 
