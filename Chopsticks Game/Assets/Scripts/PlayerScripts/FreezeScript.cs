using UnityEngine;

public class FreezeScript : Cooldown
{
    public float freezeDuration = 15f;

    // Total cooldown duration before the freeze ability can be used again (in seconds)
    public float abilityCooldown = 20f;

    // Internal timer tracking the remaining cooldown time
    private float cooldownTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Check if the F key is pressed and if the ability is off cooldown
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer <= 0)
        {
            cooldownTimer = 60;
            ActivateFreeze();
            Debug.Log("Hitting F");
            
        }
    }


    private void ActivateFreeze()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            EnemyMovementScript enemyMovement = enemy.GetComponent<EnemyMovementScript>();
            if (enemyMovement != null)
            {
                enemyMovement.freeze(freezeDuration);
            }
        }
    }


    //For cooldown UI: GetMaxValue should be the full charge value and GetCurrentValue should be the current value
    public override double GetMaxValue()
    {
        return 20f;
    }

    public override double GetCurrentValue()
    {
        return cooldownTimer;
    }
}
