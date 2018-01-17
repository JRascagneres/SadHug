using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Parameters for the camera to follow
    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject player;

    //When enabled scene has bounds the camera cant go out of
    public bool bounds;

    //Parameters for the min and max position the camera can go
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;


	void Start () {
        //Assigns player to the object in scene with tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	

	void FixedUpdate () {
        //Transforms the camera from current pos to positon of player
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posx, posy, transform.position.z);

        //If scene has bounds stops camera from following player out of area bounded by min and max camera position
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
