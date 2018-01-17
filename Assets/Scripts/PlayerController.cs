using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Parameters for player movement
    public float moveSpeed;
    private Animator anim;

	void Start () {
        //Gets the animator component for main player
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        //Checks if direction is left or right then translates accordingly 
        //Input.GetAxisRaw = -1 if input is left , Input.GetAxisRaw = 1 if input is right
        if (Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal") < 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }

        //Checks if direction is up or down then translates accordingly
        //Input.GetAxisRaw = -1 if input is down , Input.GetAxisRaw = 1 if input is up
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }

        //asigns correct animation for the inputted direction
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }
}
