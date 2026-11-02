using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoostHUD : MonoBehaviour
{
    [Header("Boost HUD")]
    [SerializeField] private Image barFill;
    [SerializeField] private TMP_Text boostPrompt;
    [SerializeField] private Color idleColor = Color.gray;
    [SerializeField] private Color activeColor = Color.white;

    private PlayerBoostSpace playerBoost;

    private void Start()
    {
        playerBoost = FindFirstObjectByType<PlayerBoostSpace>();
        UpdateHUD();
    }

    private void Update()
    {
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if (playerBoost == null)
        {
            return;
        }

        if (barFill != null)
        {
            barFill.fillAmount = playerBoost.BoostAmount;
        }

        if (boostPrompt != null)
        {
            if (playerBoost.IsBoosting)
            {
                boostPrompt.color = activeColor;
            }
            else
            {
                boostPrompt.color = idleColor;
            }
        }
    }
}
