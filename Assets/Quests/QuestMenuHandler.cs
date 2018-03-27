using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestMenuHandler : MonoBehaviour {

    public Canvas[] questCanvasArray;
    public Button closeQuestsButton;

	// Use this for initialization
	void Start () {
        updateQuests();
        Button btn = closeQuestsButton.GetComponent<Button>();
        btn.onClick.AddListener(closeMenu);
    }
	
	// Update is called once per frame
	void Update () {
        updateQuests();

    }

    void updateQuests()
    {
        for(int i = 0; i < questCanvasArray.Length; i++)
        {
            Canvas thisCanvas = questCanvasArray[i];
            Text name = thisCanvas.GetComponentsInChildren<Text>()[0];
            Text complete = thisCanvas.GetComponentsInChildren<Text>()[1];
            name.text = PlayerData.instance.data.Quests[i].Name;
            complete.text = PlayerData.instance.data.Quests[i].Complete.ToString();
        }
    }

    void closeMenu()
    {
        SceneChanger.instance.loadLevel(SceneManager.GetSceneAt(0).name);
    }
}
