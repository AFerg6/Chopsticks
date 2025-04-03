using TMPro;
using UnityEngine;

public class TalkSourceScript : MonoBehaviour, IInteractable
{
    public string[] textBlurbs;

    private int currentBlurb = 0;

    private TMP_Text speechText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speechText = gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        speechText.text = textBlurbs[0];
    }

    public void Interact()
    {
        currentBlurb++;
        if(currentBlurb < textBlurbs.Length)
            speechText.text = textBlurbs[currentBlurb];
        else
            speechText.text = textBlurbs[textBlurbs.Length - 1];
    }
}
