using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{

    private int health;
    private int maxHealth;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setMaxHealth(int health)
    {
        this.maxHealth = health;
    }

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void initializeHealth(int health)
    {
        setMaxHealth(health);
        setHealth(health);
    }

    public int takeDamage(int damageAmount)
    {
        health -= damageAmount;
        return health;
    }

    public int doHeal(int healAmount)
    {
        health += healAmount;
        return health;
    }
}
