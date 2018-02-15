using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Astract base class for character moves
/// </summary>
public abstract class CharacterMove
{

    protected BattleManager manager;
    protected Character user;
    protected Character target;
    /// <summary>The text to display when the move is executed</summary>
    protected string text;

    public Character User
    {
        get
        {
            return this.user;
        }
    }

    public Character Target
    {
        get
        {
            return this.target;
        }
    }

    public string Text
    {
        get
        {
            return this.text;
        }
    }

    /// <summary>
    /// Performs the move.
    /// </summary>
    abstract public void performMove();
}

/// <summary>
/// Special move abstract base class that expands upon CharacterMove, adding magic properties
/// </summary>
public abstract class SpecialMove : CharacterMove
{

    protected string desc;
    protected int magic;
    protected float special; // ADDED IN ASSESSMNENT 3 to faciliate saving. Changes are made below to accomodate this, i.e, children class now use this property instead.

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special"> Stat for the move's unique effect.</param>
    protected SpecialMove(string text, string desc, int magic, float special)
    {
        this.text = text;
        this.desc = desc;
        this.magic = magic;
        this.special = special;
    }

    public int Magic
    {
        get
        {
            return this.magic;
        }
    }

    public string Desc
    {
        get
        {
            return this.desc;
        }
    }

    public float Special
    {
        get
        {
            return this.special;
        }
    }
    /// <summary>
    /// Sets up the move, referencing the current instance of BattleManager, user and target
    /// </summary>
    /// <param name="manager">The battle manager</param>
    /// <param name="user">The user.</param>
    /// <param name="target">The target</param>
    public void setUp(BattleManager manager, Character user, Character target)
    {
        this.manager = manager;
        this.user = user;
        this.target = target;
    }

    /// <summary>
    /// Decreases the user's magic after <see cref="CharacterMove.performMove"/> has been called
    /// </summary>
    public void decreaseMagic()
    {
        user.Magic -= magic;
    }
}

/// <summary>
/// Basic standard attack
/// </summary>
public class StandardAttack : CharacterMove
{

    private int power;

    public StandardAttack(BattleManager manager, Character user, Character target)
    {
        this.manager = manager;
        this.user = user;
        this.target = target;
        this.power = 10;
        this.text = "attacked";
    }

    /// <summary>
    /// Calculate damage by <see cref="BattleManager.damageCalculation"/> and subtract it from target's health 
    /// </summary>
    public override void performMove()
    {
        int damage = manager.damageCalculation(user, target, power);
        target.Health -= damage;
    }
}

/// <summary>
/// Simple move to swap out the current player
/// </summary>
public class SwitchPlayers : CharacterMove
{

    public SwitchPlayers(BattleManager manager, Character user, Character target)
    {
        this.manager = manager;
        this.user = user;
        this.target = target;
        this.text = "switched with";
    }

    /// <summary>
    /// Calls <see cref="BattleManager.switchPlayers"/> to switch in the target 
    /// </summary>
    public override void performMove()
    {
        manager.switchPlayers((Player)target);
    }
}

/// <summary>
/// An attack move that uses magic
/// </summary>
public class MagicAttack : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special"> The power of the magic attack, will be rounded for damage calculation.</param>
    public MagicAttack(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Calls <see cref="BattleManager.damageCalculation"/> and subtracts this from target's health</summary>
    public override void performMove()
    {
        int damage = manager.damageCalculation(user, target, Mathf.RoundToInt(special));
        target.Health -= damage;
        decreaseMagic();
    }

}

/// <summary>
/// Lower's the target's defence
/// </summary>
public class LowerDefence : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special"> The ratio to decrease the target's defence stat by. </param>
    public LowerDefence(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Lowers the target's defence by the <see cref="decrease"/> ratio and rounds to an integer</summary>
    public override void performMove()
    {
        target.Defence = Mathf.RoundToInt(target.Defence * (1 - special));
        decreaseMagic();
    }

}

/// <summary>
/// Lower's the target's speed
/// </summary>
public class LowerSpeed : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special">  The ratio to decrease the target's speed by. </param>
    public LowerSpeed(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Lower's the target's speed by the <see cref="decrease"/> ratio and rounds to an integer</summary>
    public override void performMove()
    {
        target.Speed = Mathf.RoundToInt(target.Speed * (1 - special));
        decreaseMagic();
    }

}

/// <summary>Raise the target's attack stat</summary>
public class RaiseAttack : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special">  The ratio to increase attack by. </param>
    public RaiseAttack(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Increases the target's attack by the <see cref="increase"/> ratio and rounds to an integer</summary>
    public override void performMove()
    {
        user.Attack = Mathf.RoundToInt(user.Attack * (1 + special));
        decreaseMagic();
    }

}

/// <summary>Raises the target's defence stat</summary>
public class RaiseDefence : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special">  The ratio to increase defence by. </param>
    public RaiseDefence(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Increases the target's defence by the <see cref="increase"/> ratio and rounds to an integer</summary>
    public override void performMove()
    {
        user.Defence = Mathf.RoundToInt(user.Defence * (1 + special));
        decreaseMagic();
    }

}

/// <summary>Increases the money reward of a battle</summary>
public class IncreaseMoney : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special">  The ratio to increase the money reward by. </param>
    public IncreaseMoney(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Increases the <see cref="BattleManager.money"/> value by the <see cref="increase"/> ratio</summary>
    public override void performMove()
    {
        manager.money = Mathf.RoundToInt(manager.money * (1 + special));
        decreaseMagic();
    }

}

/// <summary>Heal a target by a set amount of health points</summary>
public class HealingSpell : SpecialMove
{

    /// <param name="text"> The text to display when the move is executed.</param>
    /// <param name="desc"> Description of the move's effect.</param>
    /// <param name="magic"> Magic amount move costs.</param>
    /// <param name="special"> The amount of health points to restore, will be rounded to nearest int. </param>
    public HealingSpell(string text, string desc, int magic, float special) : base(text, desc, magic, special)
    {
    }

    /// <summary>Increases the target's health by <see cref="increase"/> ensuring it does not go beyond 100</summary>
    public override void performMove()
    {
        if (target.Health + Mathf.RoundToInt(special) >= 100)
        {
            target.Health = 100;
        }
        else
        {
            target.Health += Mathf.RoundToInt(special);
        }
        decreaseMagic();
    }

}
