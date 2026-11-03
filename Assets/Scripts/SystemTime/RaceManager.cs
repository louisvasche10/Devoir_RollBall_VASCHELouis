using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public static float RaceTime;
    public static float TotalRaceTime = 0f;

    private bool raceStarted;
    private bool levelTimeSaved;
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
        levelTimeSaved = false;

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

    public void SaveLevelTime()
    {
        if (!levelTimeSaved)
        {
            TotalRaceTime += RaceTime;
            levelTimeSaved = true;
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

        totalDeaths = deathManager != null ? deathManager.DeathCount : 0;

        float finalTime = TotalRaceTime + RaceTime;

        trophy = GetTrophy(finalTime);

        Debug.Log("Temps du dernier niveau : " + RaceTime);
        Debug.Log("Temps total : " + finalTime);
        Debug.Log("Nombre de morts : " + totalDeaths);
        Debug.Log("Trophée : " + trophy);
    }

    private string GetTrophy(float finalTime)
    {
        if (finalTime <= 160f && ScoreManager.Score >= 5 && totalDeaths <= 2)
        {
            return "OR";
        }
        else if (finalTime <= 180f && ScoreManager.Score >= 3 && totalDeaths <= 5)
        {
            return "ARGENT";
        }
        else if (finalTime <= 210f && ScoreManager.Score >= 1 && totalDeaths <= 8)
        {
            return "BRONZE";
        }
        else
        {
            return "CACA";
        }
    }
}