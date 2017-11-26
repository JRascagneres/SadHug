using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject player;


	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	

	void FixedUpdate () {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.x, smoothTimeY);

        transform.position = new Vector3(posx, posy, transform.position.z);

    }
}
