using UnityEngine;
using TMPro;

public class JumpHUD : MonoBehaviour
{
    [Header("Jump HUD")]
    [SerializeField] private TMP_Text jumpCountText;
    [SerializeField] private TMP_Text jumpPrompt;
    [SerializeField] private Color unavailableColor = Color.gray;
    [SerializeField] private Color availableColor = Color.white;

    private void Update()
    {
        if (jumpCountText != null)
        {
            jumpCountText.text = "×" + PlayerJump.JumpCount;
        }

        if (jumpPrompt != null)
        {
            if (PlayerJump.JumpCount > 0)
            {
                jumpPrompt.color = availableColor;
            }
            else
            {
                jumpPrompt.color = unavailableColor;
            }
        }
    }
}
