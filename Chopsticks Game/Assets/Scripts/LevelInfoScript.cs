using System;
using TMPro;
using UnityEngine;

public class LevelInfoScript : MonoBehaviour
{
    public PlayerInfo playerInfo;

    private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.getLevel() >= 5)
            text.text = "Congratulations! you have completed all the levels!\nYou are truly at the top of the social ladder";
        else
            text.text = "Levels must be completed in order.\nNext level: " + (playerInfo.getLevel() + 1);
    }
}
