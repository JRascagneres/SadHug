using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestsEnum {Quest10, Level10, GeorgeLevel2};

public class Quests{
    public static Quest GetQuests(QuestsEnum quests)
    {
        switch (quests)
        {
            case QuestsEnum.Quest10:
                return new Quest(QuestType.money, "Money 10", 10);
            case QuestsEnum.Level10:
                return new Quest(QuestType.level, "Level 1", 1);
            case QuestsEnum.GeorgeLevel2:
                return new Quest(QuestType.playerLevel, "George Level 2", 2, "Gorilla");
        }

        return null;
    }
}
