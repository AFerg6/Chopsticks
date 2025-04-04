using UnityEngine;
using TMPro;
using System.Collections;

public class FarmLandCapture : MonoBehaviour
{
    public float timeRequired = 5f;
    private float timeInside = 0f;
    private bool playerInside = false;
    private bool isCompleted = false;

    public static int totalScore = 0;

    public GameObject messagePanel;
    public GameObject keyPanel;
    public GameObject key;

    private void Start()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
            if (keyPanel != null) keyPanel.SetActive(false);
        }

        if (key != null)
        {
            key.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCompleted)
        {
            Debug.Log("Player entered");
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
                CaptureFarm();
                isCompleted = true;
            }
        }
    }

    private void CaptureFarm()
    {
        totalScore += 1;

        if (messagePanel != null)
        {
            messagePanel.SetActive(true);
            StartCoroutine(HideMessageAfterDelay(3f));
        }

        if (totalScore == 3 && keyPanel != null && key != null)
        {
            keyPanel.SetActive(true);
            key.SetActive(true);
            StartCoroutine(HideKeyMessageAfterDelay(3f));
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }

    private IEnumerator HideKeyMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (keyPanel != null)
        {
            keyPanel.SetActive(false);
        }
    }
}
