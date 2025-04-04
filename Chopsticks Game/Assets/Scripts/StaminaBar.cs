using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // for once we have the sprintScript written
    public SprintScript sprintScript;
    private Image UI;

    void Start()
    {
        UI = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        float stamina = sprintScript.GetStamina(); 
        UpdateStaminaBar(stamina);
    }

    private void UpdateStaminaBar(float stamina)
    {
        // this function will update the UI stamina bar somewhere else once its created
        UI.fillAmount = stamina;

    }
}
