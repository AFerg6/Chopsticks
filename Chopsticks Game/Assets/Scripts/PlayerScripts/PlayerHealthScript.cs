using System;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    [Tooltip("The max health of the player")]
    public int maxHealth;

    [Tooltip("How many seconds of invulnerability after getting hit")]
    public float invulnTime;
    
    private int currentHealth;
    private float currentInvuln;

    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //Reduces invuln time
        if (currentInvuln > 0)
            currentInvuln -= Time.deltaTime;
    }

    public void HurtPlayer(int damage)
    {
        if (currentInvuln <= 0)
        {
            currentHealth -= damage;
            currentInvuln = invulnTime;
            if (currentHealth <= 0)
                KillPlayer();
        }
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("Main Hub");
    }
}
