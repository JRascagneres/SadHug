using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_minigame : MonoBehaviour {

    public float maxSpeed = 1;
    public float speed = 30f;
    public float jumpPower = 150f;
    public float canJump;
    public bool moving;
    public bool jumped;
    public bool wasHit;
    float groundRadius = 0.2f;
   
    //references 
    private Rigidbody2D rb2d;
    private Animator anim;
    public HealthBar hpBar;
    //stats 
    public int curHP;
    public int maxHealth;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        hpBar = gameObject.GetComponent<HealthBar>();
       
        maxHealth = 3 ;
        curHP = maxHealth;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (curHP <= 0)
        {
            Die();
        }

        if (Time.time > canJump)
        {
            anim.SetBool("jumped", false);
        } 
        
        float h = Input.GetAxis("Horizontal");
        

        ///anim.SetBool("grounded", grounded);
        /// anim.SetFloat("speed", h );

        if (Input.GetButtonDown("Jump") && Time.time > canJump && rb2d.transform.position.y < 2)
        {
            
            
            anim.SetBool("jumped", true);
            rb2d.AddForce(Vector2.up * jumpPower);
            
            canJump = Time.time + 0.25f;

   
        }
        if (curHP > maxHealth)
        {
            curHP = maxHealth;
        }

    }

    private void FixedUpdate()
    {
       
        

        float h = Input.GetAxis("Horizontal");
        /// moves player, h is -1<0>1 therfore right is -1 left is 1
        rb2d.AddForce((Vector2.right * speed) * h);

        anim.SetFloat("speed", h);


       
        /// ensures speed does not become stupidly fast
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        else if(rb2d.velocity.x < -maxSpeed)

        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
       

    }

    public void Damage(int d)
    {
        if (curHP <= 0)
        {
            Die();
        }
        else
        {
            curHP = curHP - d;
            wasHit = true;
            
        }
        
    }
    //exit minigame from here
    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
