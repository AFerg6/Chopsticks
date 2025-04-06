using UnityEngine;

public class HealScript : Cooldown
{
    public KeyCode healKey;

    public int healAmount = 1;

    private PlayerHealthScript _playerHealthScript;
    public float cooldownTime = 20f;
    private float _nextActionTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerHealthScript = GetComponent<PlayerHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(healKey) && !_playerHealthScript.isFullHealth() && Time.time >=_nextActionTime)
        {
            RestorePlayer();
            _nextActionTime = Time.time + cooldownTime;
        }
    }

    void RestorePlayer()
    {
        
        _playerHealthScript.HealPlayer(healAmount);
    }
    //For cooldown UI: GetMaxValue should be the full charge value and GetCurrentValue should be the current value
    public override double GetMaxValue()
    {
        return cooldownTime;
    }

    public override double GetCurrentValue()
    {
        return cooldownTime -(_nextActionTime - Time.time);
    }
}
