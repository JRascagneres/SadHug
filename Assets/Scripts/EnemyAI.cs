using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Speed enemy follows at 
    public float speed;

    //How far before the enemy stops chasing
    public float displacement;

    private Transform target;

    // Use this for initialization
    void Start()
    {
        //Assigns the object with tag "Player" to the object
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy is further away than displacement value transforms to target location at the speed chosen
        if (Vector2.Distance(transform.position, target.position) > displacement)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }


    }
}
