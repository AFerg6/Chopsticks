using UnityEngine;

public class ParkourPickupScript : Pickup
{
    public PlayerInfo playerInfo;
    public int value;
    public Vector3 returnPosition;
    protected override void PickupObject()
    {
        playerInfo.increaseSocialCredit(value);
        GameObject.FindGameObjectWithTag("Player").transform.position = returnPosition;
    }
}
