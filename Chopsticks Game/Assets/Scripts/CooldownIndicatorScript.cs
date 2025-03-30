using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownIndicatorScript : MonoBehaviour
{
    public string text;
    public Cooldown cooldown;
    private Image indicator;
    private double maxValue = 1;
    private double currentValue = 0;
    
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.parent.gameObject.GetComponent<TMP_Text>().text = text;
        indicator = gameObject.GetComponent<Image>();
        if(cooldown)
            maxValue = cooldown.GetMaxValue();
        
        indicator.fillAmount = (float)(currentValue / maxValue);
    }

    void Update()
    {
        if (cooldown)
        {
            currentValue = cooldown.GetCurrentValue();
            indicator.fillAmount = (float)(currentValue / maxValue);
        }
    }
}
