using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vender : MonoBehaviour
{

    private Camera c;
    private int numberOfItems = 6;
    private int numberOfItemsPerRow = 3;
    private float cellWidth = Screen.width / 4;
    private float cellHeight = Screen.height / 3;
    public Texture[] tex;
    public int[] costs;
    public GlobalFunctions.ItemTypes[] items;
    private bool draw = false;

    // Use this for initialization
    void Start()
    {
        c = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {


            for (int i = 0; i < numberOfItems; i++)
            {
                Rect bounds = new Rect(i % numberOfItemsPerRow * (cellWidth + 5), Mathf.Round(i / numberOfItemsPerRow) * (cellHeight + 5), cellWidth, cellHeight);

                if (bounds.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
                {
                    if (costs[i] <= PlayerData.instance.data.Money)
                    {
                        PlayerData.instance.data.Money -= costs[i];
                        sellItem(items[i]);
                    }
                    Debug.Log("Mouse Left pressed on: " + i.ToString());
                }

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            setDraw(false);
        }

    }

    void OnGUI()
    {
        if (draw)
        {

            for (int i = 0; i < numberOfItems; i++)
            {
                Rect bounds = new Rect(i % numberOfItemsPerRow * (cellWidth + 5), Mathf.Round(i / numberOfItemsPerRow) * (cellHeight + 5), cellWidth, cellHeight);

                GUI.DrawTexture(bounds, tex[i]);
                GUI.Label(bounds, items[i].ToString() + " costs: " + costs[i]);
            }

            Rect extra = new Rect(numberOfItemsPerRow * (cellWidth + 5), 1 * (cellHeight + 5), cellWidth, cellHeight);
            GUI.Label(extra, "You have: " + PlayerData.instance.data.Money + " Gold");




        }
    }

    public void setDraw(bool val)
    {
        draw = val;
    }

    private void sellItem(GlobalFunctions.ItemTypes item)
    {
        DataManager data = PlayerData.instance.data;
        data.addItem(GlobalFunctions.instance.createItem(item));
    }
}
