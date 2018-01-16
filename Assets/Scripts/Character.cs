using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

    //Information about characters
    private int health;
    private int maxHealth;
    private Sprite sprite;
    private bool tickingDamage = false;
    private int tickingDamagePerTurn;
    private AnimationClip idleAnimation;
    private AnimationClip castAnimation;
    private AnimationClip deathAnimation;
    private AnimationClip deadAnimation;

    //Just getters and setters for the character information
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

    public void setDeathAnimation(AnimationClip animation)
    {
        this.deathAnimation = animation;
    }

    public AnimationClip getDeathAnimation()
    {
        return this.deathAnimation;
    }

    public void setDeadAnimation(AnimationClip animation)
    {
        this.deadAnimation = animation;
    }

    public AnimationClip getDeadAnimation()
    {
        return this.deadAnimation;
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

    //Ran when character created - Sets maxHealth and then the health to the maxHealth
    public void initializeHealth(int health)
    {
        setMaxHealth(health);
        setHealth(health);
    }

    //Reduces health of character by parameter amount
    public int takeDamage(int damageAmount)
    {
        health -= damageAmount;
        return health;
    }

    //Increases health of character by parameter amount ensuring it maxes out
    public int doHeal(int healAmount)
    {
        health += healAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        return health;
    }

    //Takes ticking damage by set amount if ticking damage is true -- Ticking damage is like a poisen effect
    public void takeTickingDamage()
    {
        if (tickingDamage)
        {
            takeDamage(tickingDamagePerTurn);
        }
    }
}
