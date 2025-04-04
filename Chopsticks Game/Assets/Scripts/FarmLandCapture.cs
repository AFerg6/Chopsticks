using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FarmLandCapture : MonoBehaviour
{
    public float timeRequired = 1f; 
    private float timeInside = 0f;
    private bool playerInside = false;
    private bool isCompleted = false;

    public int scoreIncrement = 1;
    private int score = 0;
    
    public TextMeshProUGUI messagePanel;
    public TextMeshProUGUI keyPanel;
    public GameObject key;

    private void Start()
    {
        if (messagePanel != null)
        {
            messagePanel.SetText("");
            keyPanel.SetText("");
            key.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCompleted)
        {
            playerInside = true;
            timeInside = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timeInside = 0f;
        }
    }

    private void Update()
    {
        if (playerInside && !isCompleted)
        {
            timeInside += Time.deltaTime;

            if (timeInside >= timeRequired)
            {
                UpdateScore();
                isCompleted = true;
            }
        }
    }

    private void UpdateScore()
    {
        score += scoreIncrement;

        messagePanel.SetText("Captured");
        StartCoroutine(HideMessageAfterDelay(3f));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messagePanel.SetText("");
        if (score == 1 && messagePanel != null)
        {
            Debug.Log("Penis");
            keyPanel.SetText("Key Unlocked");
            key.SetActive(true);
            StartCoroutine(HideKeyMessageAfterDelay(3f)); 
        }
    }
    
    private IEnumerator HideKeyMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        keyPanel.SetText("");
    }
}