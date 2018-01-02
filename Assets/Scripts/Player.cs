using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public enum PlayerType {CompSci, Chem, Sport, Physc, Music};

    //public PlayerType playerType;

    private int maxAP = 10;
    private int currentAP = 10;
    
    public List<Ability> abilityList = new List<Ability>();
    private Abilities abilities = new Abilities();
    public Player(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.CompSci:
                initializeHealth(120);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.tenPercentCurrent));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.tenPercentTotal));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.tenHeal));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerone") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneCast"));
                break;
            case PlayerType.Chem:
                initializeHealth(150);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.groupHealTen));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.poisenTenEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.poisenTenPlayer));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playertwo") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoCast"));
                break;
            case PlayerType.Sport:
                initializeHealth(250);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunPlayer));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.poisenTenPlayer));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerthree") as Sprite);
                break;
            case PlayerType.Physc:
                initializeHealth(175);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunPlayer));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfour") as Sprite);
                break;
            case PlayerType.Music:
                initializeHealth(100);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunPlayer));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfive") as Sprite);
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
