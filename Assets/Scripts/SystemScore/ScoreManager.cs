using UnityEngine;

public static class ScoreManager
{
    public static int Score = 0;

    private const string ScoreKey = "PlayerScore";

    public static void LoadScore()
    {
        Score = PlayerPrefs.GetInt(ScoreKey, 0);
    }

    public static void AddScore(int amount)
    {
        Score += amount;
        PlayerPrefs.SetInt(ScoreKey, Score);
        PlayerPrefs.Save();

        Debug.Log("Score actuel : " + Score);
    }

    public static void ResetScore()
    {
        Score = 0;
        PlayerPrefs.SetInt(ScoreKey, Score);
        PlayerPrefs.Save();
    }
}
