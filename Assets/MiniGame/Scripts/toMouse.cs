using UnityEngine;
using System.Collections;

public class toMouse : MonoBehaviour
{

    public float bulletVelocity = 5f;
    public GameObject bullet;
    public GameObject bullet1;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    bullet1,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);
            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

            //destroys bullet in 2 secs
            Destroy(bullet, 2.0f);
        }
    }
}
   
