using UnityEngine;

public class SprintScript : MonoBehaviour
{

    public float sprintSpeed;
    public float maxStamina;
    public float recoverySpeed;
    
    private float currentStamina;
    private float defaultSpeed;
    private PlayerMovementScript p1;
    private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1 = GameObject.FindWithTag("Player").GetComponent<PlayerMovementScript>();
        defaultSpeed = p1.speed;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && (Time.time - currentTime > 1.5)){
            p1.speed = sprintSpeed;
            currentStamina -= Time.deltaTime;
        } else {
            p1.speed = defaultSpeed;
            if (currentStamina <= 0){
                currentTime = Time.time;
            }
            if (currentStamina < maxStamina){
                currentStamina += recoverySpeed * Time.deltaTime;
            }
        }
    }

    public float GetStamina()
    {
        return currentStamina / maxStamina;
    }

    
}
