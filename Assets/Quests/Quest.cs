using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType { money, level };

public class Quest {
    private string name;
    private QuestType questType;
    private bool complete;
    private int value;

    public Quest( QuestType questType, string name, int value)
    {
        this.questType = questType;
        this.complete = false;
        this.name = name;
        this.value = value;
    }

    public void setComplete()
    {
        this.complete = true;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

}
