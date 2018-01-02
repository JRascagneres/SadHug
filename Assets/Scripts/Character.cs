﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

    private int health;
    private int maxHealth;
    private Sprite sprite;
    private bool tickingDamage = false;
    private int tickingDamagePerTurn;
    private AnimationClip idleAnimation;
    private AnimationClip castAnimation;

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

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return this.sprite;
    }

    public void setIdleAnimation(AnimationClip animation)
    {
        this.idleAnimation = animation;
    }

    public AnimationClip getIdleAnimation()
    {
        return this.idleAnimation;
    }

    public void setCastAnimation(AnimationClip animation)
    {
        this.castAnimation = animation;
    }

    public AnimationClip getCastAnimation()
    {
        return this.castAnimation;
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
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        return health;
    }

    public void setTickingDamage(bool tickingDamage)
    {
        this.tickingDamage = tickingDamage;
    }

    public bool getTickingDamage()
    {
        return tickingDamage;
    }

    public void setTickingDamagePerTurn(int tickingDamagePerTurn)
    {
        this.tickingDamagePerTurn = tickingDamagePerTurn;
    }

    public int getTickingDamagePerTurn()
    {
        return tickingDamagePerTurn;
    }

    public void takeTickingDamage()
    {
        if (tickingDamage)
        {
            takeDamage(tickingDamagePerTurn);
        }
    }
}
