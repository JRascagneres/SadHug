using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

    //Information about characters
    private int _health;
    private int _maxHealth;
    private Sprite _sprite;
    private bool _tickingDamage = false;
    private int _tickingDamagePerTurn;
    private AnimationClip _idleAnimation;
    private AnimationClip _castAnimation;
    private AnimationClip _deathAnimation;
    private AnimationClip _deadAnimation;

    //Just getters and setters for the character information
    public void SetHealth(int health)
    {
        this._health = health;
    }

    public void SetMaxHealth(int health)
    {
        this._maxHealth = health;
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public void SetSprite(Sprite sprite)
    {
        this._sprite = sprite;
    }

    public Sprite GetSprite()
    {
        return this._sprite;
    }

    public void SetIdleAnimation(AnimationClip animation)
    {
        this._idleAnimation = animation;
    }

    public AnimationClip GetIdleAnimation()
    {
        return this._idleAnimation;
    }

    public void SetCastAnimation(AnimationClip animation)
    {
        this._castAnimation = animation;
    }

    public AnimationClip GetCastAnimation()
    {
        return this._castAnimation;
    }

    public void SetDeathAnimation(AnimationClip animation)
    {
        this._deathAnimation = animation;
    }

    public AnimationClip GetDeathAnimation()
    {
        return this._deathAnimation;
    }

    public void SetDeadAnimation(AnimationClip animation)
    {
        this._deadAnimation = animation;
    }

    public AnimationClip GetDeadAnimation()
    {
        return this._deadAnimation;
    }

    public void SetTickingDamage(bool tickingDamage)
    {
        this._tickingDamage = tickingDamage;
    }

    public bool GetTickingDamage()
    {
        return _tickingDamage;
    }

    public void SetTickingDamagePerTurn(int tickingDamagePerTurn)
    {
        this._tickingDamagePerTurn = tickingDamagePerTurn;
    }

    public int GetTickingDamagePerTurn()
    {
        return _tickingDamagePerTurn;
    }

    //Ran when character created - Sets maxHealth and then the health to the maxHealth
    public void InitializeHealth(int health)
    {
        SetMaxHealth(health);
        SetHealth(health);
    }

    //Reduces health of character by parameter amount
    public int TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        return _health;
    }

    //Increases health of character by parameter amount ensuring it maxes out
    public int DoHeal(int healAmount)
    {
        _health += healAmount;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        return _health;
    }
}
