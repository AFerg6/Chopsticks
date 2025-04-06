using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour, IInteractable
{
    [Tooltip("GameObject of the door part to be removed")]
    public GameObject door;

    private bool open = false;

    public void Interact()
    {
        open = true;
        Destroy(door);
    }
    
    //Moves the player through the door
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player") && open)
            other.transform.position = transform.position + (transform.forward*3f);
    }
}
