using UnityEngine;
public abstract class Pickup : MonoBehaviour
{
    protected abstract void PickupObject();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PickupObject();
            Destroy(gameObject);
        }
    }
}

