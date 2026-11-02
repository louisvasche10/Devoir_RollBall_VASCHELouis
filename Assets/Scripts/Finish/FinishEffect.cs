using UnityEngine;

public class FinishEffect : MonoBehaviour
{
    private bool hasFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (hasFinished)
        {
            return;
        }

        PlayerMovement playerMovement =
            other.GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            return;
        }

        RaceManager raceManager =
            FindFirstObjectByType<RaceManager>();

        RaceResultHUD raceResultHUD =
            FindFirstObjectByType<RaceResultHUD>();

        if (raceManager == null || raceResultHUD == null)
        {
            Debug.LogError("FinishEffect : RaceManager ou RaceResultHUD introuvable."
            );

            return;
        }

        raceManager.FinishRace();
        raceResultHUD.ShowResult();

        hasFinished = true;
    }
}