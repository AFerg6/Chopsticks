using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;
    private CharacterController controller;

    private GameObject playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveVector = moveVector.normalized;
        moveVector *= speed * Time.deltaTime;
        controller.Move(moveVector);
        
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime, 0));
        playerCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -mouseSensitivity * Time.deltaTime, 0, 0), Space.Self);
    }
}
