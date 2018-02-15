using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ALL ADDED for assesment 3
/// <summary>
/// A script to control the cars for the minigame
/// </summary>
public class CarScript : MonoBehaviour {
    /// <summary> how fast the car moves</summary>
    private float speed;
    /// <summary> which way the car is facing 1 for right and -1 for left </summary>
    private int facing;


	// Update is called once per frame
	void FixedUpdate ()
    {
        //move the car and destroy it if it leaves the bounds of the minigame
        transform.Translate(new Vector2(speed * facing, 0));
        if (transform.position.x < -10)
            Destroy(this.gameObject);
        if (transform.position.x > 30)
            Destroy(this.gameObject);
	}

    /// <summary>
    /// Set the speed of the car to a value
    /// </summary>
    /// <param name="val">the value to set the speed of the car</param>
    public void SetSpeed(float val)
    {
        speed = val;
    }
    /// <summary>
    /// Set the facing of the car to a value 1 right -1 left and flips the image as appropriate 
    /// </summary>
    /// <param name="val">the value to set the facing 1  right -1 left</param>
    public void SetFacing(int val)
    {
        facing = val;
        if (val == 1 && transform.localScale.x <= 0)
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        else if (val == -1 && transform.localScale.x >= 0)
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    

    
}
