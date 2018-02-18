using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsion : MonoBehaviour {

    //Test to see if bullet has collided with another object
    void OnCollisionEnter2D(Collision2D col)
    {
        //Checks its an object with tag "Enemy" that has collided with the bullet
        if (col.gameObject.tag == "Enemy")
        {
            ScoreScript.scoreValue++;               //Increments the score value in ScoreScript by 1 when an enemy is destroyed
            Destroy(col.gameObject);                //Destroys enemy the bullet has collided with
            Destroy(this.gameObject);               //Destroys bullet that has collided with
            
        }
        
    }
}
