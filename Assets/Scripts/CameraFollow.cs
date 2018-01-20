using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Parameters for the camera to follow
    private Vector2 _velocity;
    public float SmoothTimeX;
    public float SmoothTimeY;

    public GameObject Player;

    //When enabled scene has bounds the camera cant go out of
    public bool Bounds;

    //Parameters for the min and max position the camera can go
    public Vector3 MinCameraPos;
    public Vector3 MaxCameraPos;


	void Start () {
        //Assigns player to the object in scene with tag "Player"
        Player = GameObject.FindGameObjectWithTag("Player");
		
	}
	

	void FixedUpdate () {
        //Transforms the camera from current pos to positon of player
        float posx = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref _velocity.x, SmoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref _velocity.y, SmoothTimeY);

        transform.position = new Vector3(posx, posy, transform.position.z);

        //If scene has bounds stops camera from following player out of area bounded by min and max camera position
        if (Bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x),
                Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y),
                Mathf.Clamp(transform.position.z, MinCameraPos.z, MaxCameraPos.z));
        }
    }
}
