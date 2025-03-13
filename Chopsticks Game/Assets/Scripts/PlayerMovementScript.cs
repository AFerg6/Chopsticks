using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;
    private CharacterController controller;
    
    
    private float xRotation = 0f; // Tracks vertical rotation (pitch)

    private Transform playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerCam = Camera.main.transform;
        
        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveVector = moveVector.normalized;
        moveVector *= speed * Time.deltaTime;
        controller.Move(moveVector);

        rotatePlayerCam();
    }

    private void rotatePlayerCam()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        transform.Rotate(Vector3.up * mouseX);
        // Vertical rotation (pitch) - accumulated and clamped
        xRotation -= mouseY; // Subtract to invert vertical look (optional)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply vertical rotation to camera only
        playerCam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
