using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsion : MonoBehaviour {


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
