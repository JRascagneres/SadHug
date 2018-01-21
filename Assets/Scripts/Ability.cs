using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {

    //List of ability type enums - Different categories of abilities
    public enum AbilityTypes { NumberDamage, NumberHeal, PercentMaxHeal, PercentTotalDamage, PercentCurrentDamage, GroupNumberHeal, GroupApIncrease, EnemyStun, EnemyTickingDamage };

    //Parameters for abilities
    public string Name;
    public string Description;
    public AbilityTypes AbilityType;
    public int ApCost;
    public int EffectMagnitude;
    public bool Stun;
    public bool TickingDamage;

    //When ability is created it takes its information and saves it to the class
    public Ability(string name, AbilityTypes abilityType, string description, int apCost, int effectMagnitude, bool stun, bool tickingDamage)
    {
        this.Name = name;
        this.AbilityType = abilityType;
        this.Description = description;
        this.ApCost = apCost;
        this.EffectMagnitude = effectMagnitude;
        this.Stun = stun;
        this.TickingDamage = tickingDamage;
    }

}
