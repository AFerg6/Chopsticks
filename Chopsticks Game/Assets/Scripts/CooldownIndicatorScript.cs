using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownIndicatorScript : MonoBehaviour
{
    public string text;
    public Cooldown cooldown;
    private Image indicator;
    private double maxValue;
    private double currentValue;
    
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.parent.gameObject.GetComponent<TMP_Text>().text = text;
        indicator = gameObject.GetComponent<Image>();
        maxValue = cooldown.GetMaxValue();
        indicator.fillAmount = 1;
    }

    void Update()
    {
        currentValue = cooldown.GetCurrentValue();
        indicator.fillAmount = (float)(currentValue / maxValue);
    }
}
