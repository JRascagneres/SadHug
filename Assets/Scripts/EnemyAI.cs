using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkSpeed = 1.0f;      // Walkspeed
    public float wallLeft = 0.0f;       // Define wallLeft
    public float wallRight = 5.0f;      // Define wallRight
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX; // Original float value


    void Start()
    {
        this.originalX = this.transform.position.x;
        wallLeft = transform.position.x - 2.5f;
        wallRight = transform.position.x + 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight)
        {
            walkingDirection = -1.0f;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft)
        {
            walkingDirection = 1.0f;
        }
        transform.Translate(walkAmount);
    }
}

