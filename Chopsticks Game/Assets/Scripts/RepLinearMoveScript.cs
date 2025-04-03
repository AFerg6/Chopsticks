using UnityEngine;

public class RepLinearMoveScript : MonoBehaviour
{
    public float moveAmount = 2f; // How far to move up/down
    public float speed = 2f; // Speed of movement

    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float targetY = movingUp ? startPos.y + moveAmount : startPos.y - moveAmount;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetY, transform.position.z), speed * Time.deltaTime);

        // Stop when close enough
        if (Mathf.Abs(transform.position.y - targetY) < 0.01f)
        {
            movingUp = !movingUp;
        }
    }
}
