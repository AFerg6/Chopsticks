using TMPro;
using UnityEngine;

public class HouseDoorScript : MonoBehaviour, IUnlockable
{
    public int locked = 2;
    private TMP_Text doorText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorText = gameObject.GetComponent<TMP_Text>();
        updateText();
    }

    private void updateText()
    {
        doorText.text = "Locks: " + locked + (locked <= 0 ? "\nClick!" : "");
    }

    //Activates the level change when the door is unlocked
    public void Unlock(int amount)
    {
        locked -= amount;
        updateText();
        if (locked <= 0)
            gameObject.layer = LayerMask.NameToLayer("Interact");
    }
}
