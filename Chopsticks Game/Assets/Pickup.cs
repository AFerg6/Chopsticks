using UnityEngine;
public abstract class Pickup : MonoBehaviour
{
    protected abstract void PickupObject();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickupObject();
            Destroy(gameObject);
        }
    }
}

