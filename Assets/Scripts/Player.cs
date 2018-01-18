using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    //Player types saved in enums
    public enum PlayerType {CompSci, Physc, Music, Chem, Sport};

    //Initialised with 10 AP per character
    private int maxAP = 10;
    private int currentAP = 10;
    
    //Initialises variables
    public List<Ability> abilityList = new List<Ability>();
    private Abilities abilities = new Abilities();

    //Switches through all player types and depending on which player was chosen it sets the corresponding information for each player.
    public Player(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.CompSci:
                initializeHealth(10);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.oneHundredDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.tenPercentCurrent));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.tenPercentTotal));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.tenHeal));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerone") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneDeath"));
                break;
            case PlayerType.Physc:
                initializeHealth(10);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.groupHealTen));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.poisenTenEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.poisenTenPlayer));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playertwo") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoDeath"));
                break;
            case PlayerType.Music:
                initializeHealth(10);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunPlayer));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.poisenTenPlayer));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerthree") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeDeath"));
                break;
            case PlayerType.Chem:
                initializeHealth(10);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunPlayer));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfour") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourDeath"));
                break;
            case PlayerType.Sport:
                initializeHealth(10);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunEnemy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.singleStunPlayer));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.fiveDamage));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfive") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveDeath"));
                break;
        }
    }

    //Getters and setters for player information
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
