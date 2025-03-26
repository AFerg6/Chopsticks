using UnityEngine;

public class TestCooldown : Cooldown
{
    public double max;

    private double current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = max;
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
        if (current > max)
            current = 0;
    }

    public override double GetMaxValue()
    {
        return max;
    }

    public override double GetCurrentValue()
    {
        return current;
    }
}
