using UnityEngine;
using TMPro;
public class SocialCreditScore : MonoBehaviour
{
    public PlayerInfo player;
    private TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + player.getSocialCredit();
    }
}
