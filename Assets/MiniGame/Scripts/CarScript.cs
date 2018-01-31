using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    private float speed;
    private int facing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(new Vector2(speed * facing, 0));
        if (transform.position.x < -10)
            Destroy(this.gameObject);
        if (transform.position.x > 30)
            Destroy(this.gameObject);
	}


    public void SetSpeed(float val)
    {
        speed = val;
    }

    public void SetFacing(int val)
    {
        facing = val;
    }

    
}
