using TMPro;
using UnityEngine;

public class RemoveBlurb : MonoBehaviour
{
    public TextMeshProUGUI text;

    public string storyText;

    private string defaultText = "Some Default Text";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = storyText;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false); 
        }
    }

    public void ChangeText(string newText)
    {
        if (text != null)
        {
            text.text = newText;
        }
    }
}
