using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject optionsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("World1Level1");
        ScoreManager.ResetScore();
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
