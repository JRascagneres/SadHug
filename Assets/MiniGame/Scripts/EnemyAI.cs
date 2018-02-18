using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Parameters for enemy ai movement
    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    //Speed of enemy player
    public float speed;
    
    //Main player game object
    public GameObject player;


    void Start()
    {
        //Assigns the player to the game object with tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        //Calculates new pos x and pos y 
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        //transforms the position to the new pos x and pos y co-ords
        transform.position = new Vector3(posx, posy, transform.position.z);
    }
}
