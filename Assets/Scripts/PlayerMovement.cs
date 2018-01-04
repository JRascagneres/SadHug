﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
   
    Direction currentDir;
    Vector2 input;
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;

    public Sprite upSprite;
    public Sprite rightSprite;
    public Sprite downSprite;
    public Sprite leftSprite;

    public float walkSpeed = 1000;

    public bool isAllowedToMove = true;

	// Use this for initialization
	void Start () {
        isAllowedToMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMoving && isAllowedToMove)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //checks if keys are pressed
            if(Mathf.Abs(input.x)> Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }
            if(input != Vector2.zero)
            {
                if (input.x < 0)
                {
                    currentDir = Direction.left;
                }
                if (input.x > 0)
                {
                    currentDir = Direction.right;
                }
                if(input.y< 0)
                {
                    currentDir = Direction.down;
                }
                if (input.y > 0)
                {
                    currentDir = Direction.up;
                }

                switch (currentDir)
                {
                    case Direction.up:
                        gameObject.GetComponent<SpriteRenderer>().sprite = upSprite;
                        break;
                    case Direction.right:
                        gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
                        break;
                    case Direction.down:
                        gameObject.GetComponent<SpriteRenderer>().sprite = downSprite;
                        break;
                    case Direction.left:
                        gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
                        break;
                }
                StartCoroutine(move(transform));
            }
        }
	}

    public IEnumerator move(Transform entity)
    {
        isMoving = true;
        startPos = entity.position;
        t = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);
        while (t < 1f)
        {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;

        }
        isMoving = false;
        yield return 0;
    }
}

enum Direction
{
    up,
    right,
    down, 
    left,
}