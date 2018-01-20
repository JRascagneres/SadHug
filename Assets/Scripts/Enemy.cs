using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character{

    //Types of enemies stored with enum
    public enum EnemyType { Grunt, Grunt2};

    //Initialised with a type then infomation of each type of enemy is set
    public Enemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Grunt:
                InitializeHealth(250);
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/enemyone") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyOneIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyOneCast"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyOneDeath"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyOneDead"));
                break;
            case EnemyType.Grunt2:
                InitializeHealth(250);
                SetSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/enemytwo") as Sprite);
                SetIdleAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyTwoIdle"));
                SetCastAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyTwoCast"));
                SetDeathAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyTwoDeath"));
                SetDeadAnimation(Resources.Load<AnimationClip>("Sprites/CharacterSprites/Animations/EnemyTwoDead"));
                break;
        }
    }
}
