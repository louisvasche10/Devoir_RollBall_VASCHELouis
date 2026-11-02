using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [Header("Textes du HUD")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text scoreText;

    private void Update()
    {
        timerText.text =
            "Temps : " + RaceManager.RaceTime.ToString("F2");

        scoreText.text =
            "Score : " + ScoreManager.Score;
    }
}

