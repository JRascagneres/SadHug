using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-- This whole class was added for Assessment 3
/// <summary>
/// Class that make enemies target the main player, and move towards it 
/// </summary>

public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// Parameters for enemy ai movement, Speed of enemy player and Main player game object
    /// </summary>
  
    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    public float speed;
    
    public GameObject player;

    /// <summary>
    /// Assigns the player to the game object with tag "Player"
    /// </summary>
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// Calculates new pos x and pos y, thentransforms the position to the new pos x and pos y co-ords
    /// </summary>
    void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posx, posy, transform.position.z);
    }
}
