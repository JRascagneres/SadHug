using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public enum PlayerType {CompSci, Chem, Sport, Physc, Music};

    public PlayerType playerType;

    private int maxAP = 10;
    private int currentAP = 10;
    
    public List<Ability> abilityList = new List<Ability>();
    private Abilities abilities = new Abilities();
    public Player()
    {
        switch (playerType)
        {
            case PlayerType.CompSci:
                initializeHealth(120);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                break;
            case PlayerType.Chem:
                initializeHealth(150);
                break;
            case PlayerType.Sport:
                initializeHealth(250);
                break;
            case PlayerType.Physc:
                initializeHealth(175);
                break;
            case PlayerType.Music:
                initializeHealth(100);
                break;
        }
    }

    public void setCurrentAP(int newAP)
    {
        this.currentAP = newAP;
    }

    public int getCurrentAP()
    {
        return this.currentAP;
    }

    public int getMaxAP()
    {
        return this.maxAP;
    }

    public int useAP(int AP)
    {
        currentAP -= AP;
        return this.currentAP;
    }

    public List<Ability> getAbilities()
    {
        return abilityList;
    }
    
}
