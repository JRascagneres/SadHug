using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {
    /// <summary>
    /// Ends the scene taking you to the menu
    /// </summary>
	public void End()
    {
        Destroy(this.gameObject);
        SceneChanger.instance.loadLevel("mainmenu1",new Vector2(0,0));
    }
}
