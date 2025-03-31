using TMPro;
using UnityEngine;

public class FrontDoorScript : MonoBehaviour, IUnlockable
{
    private int locked = 2;
    private TMP_Text doorText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorText = gameObject.GetComponent<TMP_Text>();
        updateText();
    }

    private void updateText()
    {
        doorText.text = "Locks: " + locked;
    }

    //Activates the level change when the door is unlocked
    public void Unlock(int amount)
    {
        locked -= amount;
        updateText();
        if (locked <= 0)
            gameObject.GetComponent<LevelStartScript>().enabled = true;
    }
}
