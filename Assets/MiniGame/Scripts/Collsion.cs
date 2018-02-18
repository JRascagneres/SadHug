using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-- This whole class was added for Assessment 3
/// <summary>
/// Class that detects when a bullet hits an enemy, then increments the score 
/// </summary>

public class Collsion : MonoBehaviour {

    /// <summary>
    /// Method to test to see if bullet has collided with another object, then checks whether the object is an enemy,
    /// then increments the score in <see cref="ScoreScript.scoreValue"/> and deletes both bullet and enemy
    /// </summary>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            ScoreScript.scoreValue++;               
            Destroy(col.gameObject);                
            Destroy(this.gameObject);               
        } 
    }
}
