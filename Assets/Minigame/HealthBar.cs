using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image currentHealthBar;
    public Text ratioText;
    public HealthBar hpBar;
    private float hitpoint = 100;
    private float maxHP = 100;

    public Player_minigame p;

	// Use this for initialization
	void Start () {
        hpBar = gameObject.GetComponent<HealthBar>();
        
	}
	
	// Update is called once per frame
	void UpdateHealthBar () {
        float ratio = hitpoint / maxHP;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
		
	}

    public void TakeDamage()
    {
        if (p.GetComponent<Player_minigame>().wasHit == true)
        {
            hitpoint -= 1;
            p.GetComponent<Player_minigame>().wasHit = false;
        }
        
        if (hitpoint <= 0)
        {
            hitpoint = 0;
        }
        

        UpdateHealthBar();
           
    }
}
