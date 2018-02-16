using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    //Int
    public int curHP;
    public int maxHealth;

    //floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    //bools
    public bool awake = false;
    public bool lookingRight = true;

    //ref
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPoint;


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
   


    // Use this for initialization
    void Start () {
        curHP = maxHealth;
        shootPoint = shootPoint.GetComponent<Transform>().transform;
        Wait();
    }
	
	// Update is called once per frame
	void Update () {

        rangeCheck();
        attack();

    }
    void rangeCheck()
    {
        awake = true;
       
    }
    public void attack()
    {

        bulletTimer += Time.deltaTime;

        if(bulletTimer > shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bulletClone.GetComponent <Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletTimer = 0;
        }

        
    }
}
