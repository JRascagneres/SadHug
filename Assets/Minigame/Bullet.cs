using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool hasTrig=false;
    public HealthBar hpBar;


    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.isTrigger != true && hasTrig == false)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Player_minigame>().Damage(1);
                hasTrig = true;
                hpBar.TakeDamage();
                waitAndDestory();
            }
            
        }
    }

    IEnumerator waitAndDestory()
    {
        yield return new WaitForSeconds(2);
        //Destroy(gameObject);
    }
    
    // Use this for initialization
    void Start () {
        hpBar = hpBar.GetComponent<HealthBar>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
