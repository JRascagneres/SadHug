using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;



public class QuestManager : MonoBehaviour {
    List<Quest> quests = new List<Quest>();

    public Canvas[] questCanvas;

    private Dropdown[] questDropdowns;

    GameObject player;

    void Start()
    {

        player = GameObject.Find("Player");
        player.SetActive(false);

        questDropdowns = new Dropdown[3];
        List<string> questStrings = new List<String>();

        foreach (QuestsEnum questEnum in Enum.GetValues(typeof(QuestsEnum)))
        {
            questStrings.Add(Quests.GetQuests(questEnum).Name);
        }

        for (int i = 0; i < questDropdowns.Length; i++)
        {
            questDropdowns[i] = questCanvas[i].GetComponentInChildren<Dropdown>();
            questDropdowns[i].AddOptions(questStrings);
        }

    }



	public void setQuests()
    {
        PlayerData.instance.data.Quests = quests.ToArray();
    }

    public void startGame()
    {

        bool success = true;

        for(int i = 0; i < questDropdowns.Length; i++)
        {
            QuestsEnum questsEnum = ((QuestsEnum)questDropdowns[i].value);
            Quest quest = Quests.GetQuests(questsEnum);
            
            for(int j = 0; j < quests.Count; j++)
            {
                if(quests[j].Name == quest.Name)
                {
                    success = false;
                }
            }

            quests.Add(quest);
        }

        if (success)
        {

            //Load level
            PlayerData.instance.data = new DataManager(
                new Player("George", 1, 100, 5, 5, 5, 5, 5, 5, 0, null,
                    new MagicAttack("hi-jump kicked", "Kick with power 15", 3, 15),
                    new RaiseDefence("buffed up against", "Increase your defence by 10%", 2, 0.1f),
                    (Texture2D)Resources.Load("Character1", typeof(Texture2D))));
            PlayerData.instance.data.addPlayer(new Player("Hannah", 1, 100, 5, 3, 5, 5, 15, 5, 0, null,
                    new IncreaseMoney("stole money from", "Increase money returns by 50%", 2, 0.5f),
                    new MagicAttack("threw wine battles at", "Throw wine bottles with damage 15", 2, 15),
                    (Texture2D)Resources.Load("Character2", typeof(Texture2D))));
            GlobalFunctions.instance.currentLevel = 0;
            GlobalFunctions.instance.objectsActive = new Dictionary<string, bool>();

            setQuests();

            SoundManager.instance.playSFX("interact");
            player.SetActive(true);
            SceneChanger.instance.loadLevel("CS-Jail", new Vector2(0, 0));
        }
        else
        {
            quests = new List<Quest>();
        }
    }
}
