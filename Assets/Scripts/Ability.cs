using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {

    public enum abilityTypes { numberDamage, numberHeal, percentTotalDamage, percentCurrentDamage, groupNumberHeal, enemyStun, enemyTickingDamage, playerTickingDamage, playerStun };
    public string name;
    public string description;
    public abilityTypes abilityType;
    public int apCost;
    public int effectMagnitude;
    public bool stun;
    public bool tickingDamage;

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
