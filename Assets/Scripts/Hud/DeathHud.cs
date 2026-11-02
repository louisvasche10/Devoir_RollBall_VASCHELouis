using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHUD : MonoBehaviour
{
    [Header("Écran de mort")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private TMP_Text deathCountText;
    [SerializeField] private GameObject gameHUD;

    [Header("Animation")]
    [SerializeField] private float countAnimationDuration = 0.8f;
    [SerializeField] private float restartDelay = 1.2f;

    private DeathManager deathManager;
    private bool isShowing;

    private void Awake()
    {
        deathScreen.SetActive(false);
    }

    private void Start()
    {
        deathManager = FindFirstObjectByType<DeathManager>();

        if (deathManager == null)
        {
            Debug.LogError("DeathHUD : aucun DeathManager trouvé dans la scène.");
            return;
        }

        deathManager.OnPlayerDied += ShowDeathScreen;
        Debug.Log("DeathHUD : abonnement à l'événement réussi.");
    }

    private void OnDestroy()
    {
        if (deathManager != null)
        {
            deathManager.OnPlayerDied -= ShowDeathScreen;
        }
    }

    private void ShowDeathScreen(int previousCount, int currentCount)
    {
        Debug.Log("DeathHUD : événement de mort reçu !");
        if (isShowing)
        {
            return;
        }

        isShowing = true;

        if (gameHUD != null)
        {
            gameHUD.SetActive(false);
        }

        Time.timeScale = 0f;
        deathScreen.SetActive(true);

        StartCoroutine(DeathSequence(previousCount, currentCount));
    }

    private IEnumerator DeathSequence(int previousCount, int currentCount)
    {
        float timer = 0f;

        while (timer < countAnimationDuration)
        {
            timer += Time.unscaledDeltaTime;

            float progress = Mathf.Clamp01(
                timer / countAnimationDuration
            );

            int displayedCount = Mathf.RoundToInt(
                Mathf.Lerp(previousCount, currentCount, progress)
            );

            deathCountText.text = displayedCount.ToString();

            yield return null;
        }

        deathCountText.text = currentCount.ToString();

        yield return new WaitForSecondsRealtime(restartDelay);

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}