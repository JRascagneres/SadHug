using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ALL ADDED for the ASSESSMENT 3 took some code from assessment 2's PlayerMovemnt.cs
/// <summary>
/// The movement for the minigame character, includes movement and progression control
/// </summary>
public class MiniMove : MonoBehaviour {
    private float speed = 0.1f;
    private string lastMove = "Idle";
    private bool canMove = true;
    private Animator anim;
    private float xstart;
    private float ystart;
    private GameObject controller;
    /// <summary>the number of lives the player has </summary>
    private int lives = 3;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponentInParent<Animator>();
        xstart = transform.position.x;
        ystart = transform.position.y;
        controller = GameObject.Find("CarController");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //hard restart the player can perform 
        if (Input.GetKeyDown(KeyCode.R))
        {
            controller.GetComponent<CarController>().Restart();
            lives = 3;
            transform.position = new Vector2(xstart, ystart);
    }
        //movement controlls 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move("Up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move("Down");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move("Left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move("Right");
        }
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            setIdle();
        }
        //when at the top go to the next level
        if (transform.position.y > 0)
            levleup();

    }

    public void OnGUI()
    {
        //draw on the GUI how many lives the player has
        Rect bounds = new Rect(240, 40, 340, 140);
        GUI.Label(bounds, "Lives: " + lives + " /3");
    }

    /// <summary>
    /// The player movement, it takes a direction and moves the player while setting the animation
    /// </summary>
    /// <param name="direction"></param>
    public void move(string direction)


    {
        if (canMove)
        {
            walkAnimation(direction);
            Vector2 translation;
            switch (direction)
            {
                case "Up":
                    translation = Vector2.up;
                    break;
                case "Down":
                    translation = Vector2.down;
                    break;
                case "Left":
                    translation = Vector2.left;
                    break;
                case "Right":
                    translation = Vector2.right;
                    break;
                default:
                    translation = Vector2.zero;
                    break;
            }
            transform.Translate(translation * speed);
            
        }
    }
    /// <summary>
    /// Sets the player to the idle animation
    /// </summary>
    private void setIdle()
    {
        if (lastMove != "Idle")
        {
            anim.SetTrigger("Idle" + lastMove);
            lastMove = "Idle";
        }
    }
    /// <summary>
    /// Sets the player to a walking animation with a gicven direction
    /// </summary>
    /// <param name="direction"> the direction of which to move </param>
    private void walkAnimation(string direction)
    {
        if (lastMove != direction)
        {
            anim.SetTrigger("Walk" + direction);
            lastMove = direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      //reduce lives by 1 and if less than or equal to zero restart the minigame
        if (collision.tag=="Car")
        {
            lives -= 1;
            if (lives<=0)
            {
                controller.GetComponent<CarController>().Restart();
                lives = 3;

            }

            transform.position = new Vector2(xstart, ystart);
        }
    }
    /// <summary>
    /// go to the next level involves telling the Carcontroller and going back to the start location
    /// </summary>
    private void levleup()
    {
        transform.position = new Vector2(xstart, ystart);
        controller.GetComponent<CarController>().ChangeSpeed(1.1f);
    }
}

