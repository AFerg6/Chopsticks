using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    [Tooltip("The max health of the player")]
    public int maxHealth;
    private int currentHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            KillPlayer();
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("Main Hub");
    }
}
