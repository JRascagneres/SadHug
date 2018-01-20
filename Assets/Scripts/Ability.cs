using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {

    //List of ability type enums - Different categories of abilities
    public enum abilityTypes { numberDamage, numberHeal, percentMaxHeal, percentTotalDamage, percentCurrentDamage, groupNumberHeal, groupAPIncrease, enemyStun, enemyTickingDamage, playerTickingDamage, playerStun, randomAttack };

    //Parameters for abilities
    public string name;
    public string description;
    public abilityTypes abilityType;
    public int apCost;
    public int effectMagnitude;
    public bool stun;
    public bool tickingDamage;

    //When ability is created it takes its information and saves it to the class
    public Ability(string name, abilityTypes abilityType, string description, int apCost, int effectMagnitude, bool stun, bool tickingDamage)
    {
        this.name = name;
        this.abilityType = abilityType;
        this.description = description;
        this.apCost = apCost;
        this.effectMagnitude = effectMagnitude;
        this.stun = stun;
        this.tickingDamage = tickingDamage;
    }

}
