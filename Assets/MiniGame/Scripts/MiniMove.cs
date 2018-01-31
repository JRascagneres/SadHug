using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMove : MonoBehaviour {
    private float speed = 0.1f;
    private string lastMove = "Idle";
    private bool canMove = true;
    private Animator anim;
    private float xstart;
    private float ystart;
    private GameObject controller;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponentInParent<Animator>();
        xstart = transform.position.x;
        ystart = transform.position.y;
        controller = GameObject.Find("CarController");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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

        if (transform.position.y > 0)
            levleup();

    }
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
    private void setIdle()
    {
        if (lastMove != "Idle")
        {
            anim.SetTrigger("Idle" + lastMove);
            lastMove = "Idle";
        }
    }

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
        Debug.Log("Hit" + (string)collision.tag);
        if (collision.tag=="Car")
        {
            transform.position = new Vector2(xstart, ystart);
        }
    }

    private void levleup()
    {
        transform.position = new Vector2(xstart, ystart);
        controller.GetComponent<CarController>().ChangeSpeed(1.1f);
    }
}

