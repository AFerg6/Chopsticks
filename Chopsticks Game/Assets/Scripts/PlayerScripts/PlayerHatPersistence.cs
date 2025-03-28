using UnityEngine;

public class PlayerHatPersistence : MonoBehaviour
{
    public PlayerInfo playerInfo;

    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerInfo.GetHat())
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player.transform.GetChild(0).childCount > 0)
            {
                Destroy(player.transform.GetChild(0).GetChild(0).gameObject);
            }

            Instantiate(playerInfo.GetHat(), player.transform.GetChild(0));
        }
    }
}
