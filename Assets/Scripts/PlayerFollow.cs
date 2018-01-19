using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    //Speed enemy follows at 
    public float speed;

    //How far before the enemy stops chasing
    public float displacement;

    private Animator anim;

    private Transform target;

    // Use this for initialization
    void Start()
    {
        //Assigns the object with tag "Player" to the object
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy is further away than displacement value transforms to target location at the speed chosen
        if (Vector2.Distance(transform.position, target.position) > displacement)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        }

    }
}