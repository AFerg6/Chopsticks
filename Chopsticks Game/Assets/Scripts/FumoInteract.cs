using System;
using Unity.VisualScripting;
using UnityEngine;

public class FumoPetScript : MonoBehaviour
{
    
    [SerializeField] private bool triggerActive = false;

    public GameObject player;
    public bool hasFumo = false;
    public GameObject fumoPrefab;
    public int triggerCount = 0;
    public float interactNumCooldown = 3f;
    private AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }


    //detects when the player is within the interact range
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    
  


    // Update is called once per frame
    void Update()
    {
        if (triggerActive && Input.GetMouseButtonDown(0))
        {
            triggerCount++;
            interactNumCooldown = 3f;
            
            if (triggerCount == 9)
            {
                triggerCount = 0;
                audioData.Play(0);
            }
            
            if( triggerCount ==1)
            {
                toggleFumo();
            }

            
            
            
        }

        if(triggerCount > 0)
        {
            interactNumCooldown -= Time.deltaTime;
        }
        
        if (interactNumCooldown <= 0.0f)
        {
            triggerCount = 0;
            interactNumCooldown = 3f;
        }
    }
    
    private void toggleFumo()
    {

        GameObject fumoObj = GameObject.Find("fumo(pet)");
        
        // Debug.Log(fumoObj);
        
        
        //if player doesnt have the fumo pet attached to them adds the fumo prefab as a child to the player
        if ( fumoObj == null)
        {
            GameObject fumo = Instantiate(fumoPrefab, player.transform);
            fumo.name = "fumo(pet)";
            hasFumo = true;
        }
        else
        {
            Destroy(fumoObj);
        }
    }
    
    
}
