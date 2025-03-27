using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUiScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static PlayerHealthScript healthScript;
    private GameObject[] healthBar;
    public GameObject healthBarPrefab;
    private int healthIcons;
    void Start()
    {
        
        healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
        
        healthBar = new GameObject[healthScript.maxHealth];
        healthIcons = healthScript.maxHealth;
        
        for (int i = 0; i < healthScript.maxHealth; i++)
        {

            generateHealthIcon(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthIcons > healthScript.getCurrentHealth())
        {
            Destroy(healthBar[healthIcons-1]);
            healthIcons--;
            Console.WriteLine("decrease health icon");
        }else if (healthIcons < healthScript.getCurrentHealth())
        {
            generateHealthIcon(healthScript.getCurrentHealth()-1);
            Console.WriteLine("increase health icon");
        }
    }

    private void generateHealthIcon(int pos)
    {
        Vector3 healthPosition = transform.position + new Vector3(100*pos, 0f, 0f);
        Quaternion healthRotation = transform.rotation;
        GameObject healthIcon = Instantiate(healthBarPrefab, healthPosition, healthRotation, transform);
            
            
        healthIcon.name = "HealthIcon" + pos;
      
            
        healthBar[pos] = healthIcon;
    }
    
}
