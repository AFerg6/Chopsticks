using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndPickup : Pickup
{
    public PlayerInfo playerInfo;
    public int value;
    
    protected override void PickupObject()
    {
        playerInfo.increaseSocialCredit(value);
        playerInfo.increaseLevel();
        SceneManager.LoadScene("Main Hub");
    }
}
