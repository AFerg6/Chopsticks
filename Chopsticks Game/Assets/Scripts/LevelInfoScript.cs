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
        text.text = "Levels must be completed in order.\nNext level: " + Math.Min(playerInfo.getLevel() + 1, 5);
    }
}
