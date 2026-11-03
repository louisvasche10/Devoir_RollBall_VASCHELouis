using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class RaceResultHUD : MonoBehaviour
{
    [Header("Écran de fin")]
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TMP_Text resultText;

    [Header("HUD à masquer")]
    [SerializeField] private GameObject[] otherHUDs;

    [Header("Retour menu")]
    [SerializeField] private string mainMenuScene = "MainMenu";
    [SerializeField] private float returnDelay = 10f;

    private RaceManager raceManager;

    private void Awake()
    {
        endScreen.SetActive(false);
    }

    private void Start()
    {
        raceManager = FindFirstObjectByType<RaceManager>();
    }

    public void ShowResult()
    {
        endScreen.SetActive(true);

        foreach (GameObject hud in otherHUDs)
        {
            hud.SetActive(false);
        }

        float finalTime = RaceManager.TotalRaceTime + RaceManager.RaceTime;

        resultText.text = "Course terminée !\n\n"
            + "Trophée : " + raceManager.Trophy + "\n\n"
            + "Temps total : " + finalTime.ToString("F2") + " secondes\n"
            + "Score : " + ScoreManager.Score + "\n"
            + "Morts : " + raceManager.TotalDeaths;

        Time.timeScale = 0f;
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSecondsRealtime(returnDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}
