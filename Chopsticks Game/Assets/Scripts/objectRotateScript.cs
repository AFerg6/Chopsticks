using UnityEngine;

public class objectRotateScript : MonoBehaviour
{

    public float xSpeed;

    public float ySpeed;

    public float zSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }
}
