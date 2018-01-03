using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character{

    //Types of enemies stored with enum
    public enum EnemyType { Grunt, TestBoi};

    //Initialised with a type then infomation of each type of enemy is set
    public Enemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Grunt:
                initializeHealth(100);
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/enemyone") as Sprite);
                break;
            case EnemyType.TestBoi:
                initializeHealth(1000);
                setSprite(Resources.Load<Sprite>("Sprites/CharacterSprites/enemyone") as Sprite);
                break;
        }
    }
}
