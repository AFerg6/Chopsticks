using System;
using UnityEngine;

public class KillPlaneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
            other.gameObject.GetComponent<PlayerHealthScript>().KillPlayer();
    }
}
