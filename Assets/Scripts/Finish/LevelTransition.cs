using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private LevelSequence levelSequence;

    public void LoadNextLevel(int currentLevelIndex)
    {
        if (levelSequence == null)
        {
            Debug.LogError("LevelSequence is missing!");
            return;
        }

        string[] scenes = levelSequence.levelScenes;

        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex >= scenes.Length)
        {
            Debug.Log("No next level available.");
            return;
        }

        string nextScene = scenes[nextLevelIndex];

        if (string.IsNullOrWhiteSpace(nextScene))
        {
            Debug.LogError("Next scene name is empty!");
            return;
        }

        SceneManager.LoadScene(nextScene);
    }
}
