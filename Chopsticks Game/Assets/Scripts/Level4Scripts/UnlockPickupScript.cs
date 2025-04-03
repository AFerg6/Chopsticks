using System;
using UnityEngine;

public class UnlockPickupScript : Pickup
{
    public GameObject unlockTarget;
    [Tooltip("How much unlocking to do on pikcup")]
    public int unlockPower;
    private IUnlockable targetComponent;

    private void Start()
    {
        targetComponent = unlockTarget.GetComponent<IUnlockable>();
    }

    protected override void PickupObject()
    {
        if(targetComponent != null)
            targetComponent.Unlock(unlockPower);
    }
}
