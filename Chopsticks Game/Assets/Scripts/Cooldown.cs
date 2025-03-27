using UnityEngine;
//Can't be an interface because they aren't serializable
public abstract class Cooldown : MonoBehaviour
{
    public abstract double GetMaxValue();
    public abstract double GetCurrentValue();
}
