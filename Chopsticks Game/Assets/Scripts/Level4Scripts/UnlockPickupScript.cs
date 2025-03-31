using UnityEngine;

public class UnlockPickupScript : Pickup
{
    public IUnlockable target;
    protected override void PickupObject()
    {
        target.Unlock(1);
    }
}
