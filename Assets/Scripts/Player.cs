using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    //Player types saved in enums
    public enum PlayerType {CompSci, Physc, Music, Chem, Sport};

    //Initialised with 10 AP per character
    private int _maxAp = 10;
    private int _currentAp = 10;
    
    //Initialises variables
    public List<Ability> AbilityList = new List<Ability>();
    private Abilities _abilities = new Abilities();

    //Switches through all player types and depending on which player was chosen it sets the corresponding information for each player.
    public Player(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.CompSci:
                InitializeHealth(125);
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.Complain));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.ChangingVariables));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.EnterTheMatrix));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.BasicAttack));
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerone") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneCast"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneDead"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerOneDeath"));
                break;
            case PlayerType.Physc:
                InitializeHealth(175);
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.ReversePsychology));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.Therapy));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.ReadingWeak));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.BasicAttack));
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playertwo") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoCast"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoDead"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerTwoDeath"));
                break;
            case PlayerType.Music:
                InitializeHealth(100);
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.Dischord));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.Harmony));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.HearingDamage));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.BasicAttack));
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerthree") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeCast"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeDead"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerThreeDeath"));
                break;
            case PlayerType.Chem:
                InitializeHealth(150);
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.ChemicalSpill));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.NoxiousGas));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.ExplosiveReagents));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.BasicAttack));
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfour") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourCast"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourDead"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFourDeath"));
                break;
            case PlayerType.Sport:
                InitializeHealth(250);
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.PepTalk));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.HockeyClub));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.Rko));
                AbilityList.Add(_abilities.GetAbility(Abilities.AbilityEnum.BasicAttack));
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/playerfive") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveCast"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveDead"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/PlayerFiveDeath"));
                break;
        }
    }

    //Getters and setters for player information
    public void SetCurrentAp(int newAp)
    {
        this._currentAp = newAp;
    }

    public void GiveAp(int ap)
    {
        this._currentAp = this._currentAp + ap;
        if (this._currentAp > this._maxAp)
        {
            this._currentAp = this._maxAp;
        }
    }

    public int GetCurrentAp()
    {
        return this._currentAp;
    }

    public int GetMaxAp()
    {
        return this._maxAp;
    }

    public int UseAp(int ap)
    {
        _currentAp -= ap;
        return this._currentAp;
    }

    public List<Ability> GetAbilities()
    {
        return AbilityList;
    }
    
}
