using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static float RaceTime;

    private bool raceStarted;
    private DeathManager deathManager;

    private int totalDeaths;
    private string trophy;

    public int TotalDeaths
    {
        get { return totalDeaths; }
    }

    public string Trophy
    {
        get { return trophy; }
    }

    private void Start()
    {
        ScoreManager.LoadScore();
        RaceTime = 0f;
        raceStarted = true;

        deathManager = FindFirstObjectByType<DeathManager>();

        if (deathManager == null)
        {
            Debug.LogError("RaceManager : aucun DeathManager trouvé.");
        }
        else
        {
            deathManager.OnPlayerDied += StopRaceTimer;
        }
    }

    private void Update()
    {
        if (raceStarted)
        {
            RaceTime += Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        if (deathManager != null)
        {
            deathManager.OnPlayerDied -= StopRaceTimer;
        }
    }

    private void StopRaceTimer(int previousCount, int currentCount)
    {
        raceStarted = false;
    }

    public void FinishRace()
    {
        if (!raceStarted)
        {
            return;
        }

        raceStarted = false;

        totalDeaths = deathManager != null ? deathManager.DeathCount: 0;

        trophy = GetTrophy();

        Debug.Log("Nombre de morts : " + totalDeaths);
        Debug.Log("Trophée : " + trophy);
    }

    private string GetTrophy()
    {
        if (RaceTime <= 60f && ScoreManager.Score >= 5 && totalDeaths <= 1)
        {
            return "OR";
        }
        else if (RaceTime <= 90f && ScoreManager.Score >= 3 && totalDeaths <= 3)
        {
            return "ARGENT";
        }
        else if (RaceTime <= 120f && ScoreManager.Score >= 1)
        {
            return "BRONZE";
        }
        else
        {
            return "CACA";
        }
    }
}

