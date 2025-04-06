using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed;
    public float mouseSensitivity;
    public float jumpForce;
    public float coyoteTime = 0.25f;
    
    private Rigidbody rb;
    private Animator animator;
    
    private float xRotation = 0f; // Tracks vertical rotation (pitch)
    private float remainingCoyoteTime;
    private float jumpLockout; //For preventing double jumping by mashing jump
    private bool grounded;
    private bool wasGrounded;
    private Transform playerCam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCam = Camera.main.transform;
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        
        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveVector = moveVector.normalized;
        rb.linearVelocity = (moveVector * speed) + (Vector3.up * rb.linearVelocity.y);
        animator.SetFloat("MoveSpeed", moveVector.magnitude);

        wasGrounded = grounded;
        grounded = checkGrounded();
        animator.SetBool("Grounded", grounded);
        
        if(Input.GetButtonDown("Jump"))
            if((grounded || remainingCoyoteTime > 0) && jumpLockout <= 0)
                jump();
        
        rotatePlayerCam();
        
        //Time to count as grounded after leaving the ground
        if (remainingCoyoteTime > 0)
            remainingCoyoteTime -= Time.deltaTime;
        
        //Decrements jump lockout
        if (jumpLockout > 0)
            jumpLockout -= Time.deltaTime;

        if (wasGrounded && !grounded)
            remainingCoyoteTime = coyoteTime;
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

    private void jump()
    {
        rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
        grounded = false;
        wasGrounded = false;
        jumpLockout = 0.4f;
    }

    private bool checkGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.2f);
    }
}
