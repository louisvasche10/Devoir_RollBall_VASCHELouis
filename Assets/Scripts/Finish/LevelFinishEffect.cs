using UnityEngine;

public class LevelFinishEffect : MonoBehaviour
{
    [SerializeField] private LevelTransition levelTransition;
    [SerializeField] private int currentLevelIndex;

    private bool hasFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (hasFinished)
        {
            return;
        }

        PlayerMovement playerMovement =
            other.GetComponentInParent<PlayerMovement>();

        if (playerMovement == null)
        {
            return;
        }

        if (levelTransition == null)
        {
            Debug.LogError("LevelFinishEffect : LevelTransition manquant.");
            return;
        }

        hasFinished = true;
        levelTransition.LoadNextLevel(currentLevelIndex);
    }
}