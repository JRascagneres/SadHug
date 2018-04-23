using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// A monobehaviour object to handle the quest progress menu
/// </summary>
public class QuestMenuHandler : MonoBehaviour {

    public Canvas[] questCanvasArray;
    public Text completionStatus;
    public Button closeQuestsButton;

	// Updates quest completeness
	void Start () {
        updateQuests();

        if (PlayerData.instance.data.CompletedQuests)
        {
            completionStatus.text = "Quests Complete!";
        }
        else
        {
            completionStatus.text = "Not Yet Complete!";
        }

        Button btn = closeQuestsButton.GetComponent<Button>();
        btn.onClick.AddListener(closeMenu);
    }

    /// <summary>
    /// A function to check whether the quests are complete and updates the status. If they all are the reward is given
    /// </summary>
    void checkQuests()
    {
        Quest[] quests = PlayerData.instance.data.Quests;
        bool completedAll = true;

        for(int i = 0; i < quests.Length; i++)
        {
            switch (quests[i].QuestType)
            {
                case QuestType.level:
                    if(GlobalFunctions.instance.currentLevel >= quests[i].Value)
                    {
                        quests[i].Complete = true;
                    }
                    break;

                case QuestType.money:
                    if (PlayerData.instance.data.Money >= quests[i].Value)
                    {
                        quests[i].Complete = true;
                    }
                    break;
                case QuestType.playerLevel:
                    int playerIndex = getPlayerIndexFromName(quests[i].OtherData);
                    if(playerIndex != -1)
                    {
                        if (PlayerData.instance.data.Players[playerIndex].Level >= quests[i].Value)
                        {
                            quests[i].Complete = true;
                        }
                    }
                    break;
            }

            if (!quests[i].Complete)
            {
                completedAll = false;
            }
        }
        PlayerData.instance.data.CompletedQuests = completedAll;
        giveReward();
    }

    /// <summary>
    /// Updates the quest UI to show if they are complete
    /// </summary>
    void updateQuests()
    {
        if (!PlayerData.instance.data.CompletedQuests)
        {
            checkQuests();
        }

        for (int i = 0; i < questCanvasArray.Length; i++)
        {
            Canvas thisCanvas = questCanvasArray[i];
            Text name = thisCanvas.GetComponentsInChildren<Text>()[0];
            Text complete = thisCanvas.GetComponentsInChildren<Text>()[1];
            name.text = PlayerData.instance.data.Quests[i].Name;
            complete.text = PlayerData.instance.data.Quests[i].Complete.ToString();
        }
    }

    /// <summary>
    /// Gives winning reward
    /// </summary>
    void giveReward()
    {
        PlayerData.instance.data.Money += 1000;
    }


    /// <summary>
	/// Gets player from the name of the player. Used to check player level in one of the possible quests.
	/// </summary>
	/// <returns>Player index</returns>
    int getPlayerIndexFromName(string name)
    {
        Player[] players = PlayerData.instance.data.Players;
        for(int i = 0; i < players.Length; i++)
        {
            Player player = players[i];
            if(player != null)
            {
                if(player.Name == name)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    /// <summary>
	/// Closes quest menu
	/// </summary>
    void closeMenu()
    {
        SceneChanger.instance.loadLevel(SceneManager.GetSceneAt(0).name);
    }
}
