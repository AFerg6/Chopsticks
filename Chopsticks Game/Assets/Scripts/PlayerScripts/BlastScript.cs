using UnityEngine;

public class BlastScript : Cooldown
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //For cooldown UI: GetMaxValue should be the full charge value and GetCurrentValue should be the current value
    public override double GetMaxValue()
    {
        return 0;
    }

    public override double GetCurrentValue()
    {
        return 0;
    }
}
