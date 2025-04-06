using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartScript : MonoBehaviour, IInteractable
{
    public string levelName;
    public int levelRequirement;
    public PlayerInfo playerInfo;
    public void Interact()
    {
        if(playerInfo.getLevel() >= levelRequirement)
            SceneManager.LoadScene(levelName);
    }
}
