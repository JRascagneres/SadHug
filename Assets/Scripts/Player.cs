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
                initializeHealth(125);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.complain));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.changingVariables));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.enterTheMatrix));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.basicAttack));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerone") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneDeath"));
                break;
            case PlayerType.Physc:
                initializeHealth(175);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.reversePsychology));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.therapy));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.readingWeak));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.basicAttack));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playertwo") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoDeath"));
                break;
            case PlayerType.Music:
                initializeHealth(100);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.dischord));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.harmony));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.hearingDamage));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.basicAttack));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerthree") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeDeath"));
                break;
            case PlayerType.Chem:
                initializeHealth(150);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.chemicalSpill));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.noxiousGas));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.explosiveReagents));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.basicAttack));
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfour") as Sprite);
                setIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourIdle"));
                setCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourCast"));
                setDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourDead"));
                setDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourDeath"));
                break;
            case PlayerType.Sport:
                initializeHealth(250);
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.pepTalk));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.hockeyClub));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.rko));
                abilityList.Add(abilities.getAbility(Abilities.AbilityEnum.basicAttack));
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

    public void giveAP(int AP)
    {
        this.currentAP = this.currentAP + AP;
        if (this.currentAP > this.maxAP)
        {
            this.currentAP = this.maxAP;
        }
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
