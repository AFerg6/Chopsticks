using System;
using UnityEngine;

public class OpenLockedDoorScript : MonoBehaviour
{
    public GameObject lockedDoor;
    public AudioSource audioData;

    private void Start()
    {
        audioData.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            audioData.Play();
            Destroy(lockedDoor);
        }
    }
}
