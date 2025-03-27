using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    public PlayerInfo playerInfo;
    private GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Physics.Raycast(camera.transform.position + (camera.transform.forward * 0.5f), camera.transform.forward, out hit);
            if (hit.transform)
            {
                if (hit.transform.gameObject.GetComponent<LevelStartScript>())
                {
                    hit.transform.gameObject.GetComponent<LevelStartScript>().OnInteract(playerInfo.getLevel());
                }
            }
        }
    }
}
