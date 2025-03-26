using UnityEngine;

public class CurrencyPickup : Pickup
{
    public PlayerInfo playerInfo;
    public int value;
    
    protected override void PickupObject()
    {
        //Uncomment after merge
        playerInfo.increaseSocialCredit(value);
    }
}
