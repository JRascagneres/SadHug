using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {

    public enum abilityTypes { numberDamage, numberHeal, percentTotalDamage, percentCurrentDamage};
    public string name;
    public string description;
    public abilityTypes abilityType;
    public int apCost;
    public int effectMagnitude;

    public Ability(string name, abilityTypes abilityType, string description, int apCost, int effectMagnitude)
    {
        this.name = name;
        this.abilityType = abilityType;
        this.description = description;
        this.apCost = apCost;
        this.effectMagnitude = effectMagnitude;
    }

}
