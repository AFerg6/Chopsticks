using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartScript : MonoBehaviour
{
    public string levelName;
    public int levelRequirement;
    public void OnInteract(int level)
    {
        if(level >= levelRequirement)
            SceneManager.LoadScene(levelName);
    }
}
