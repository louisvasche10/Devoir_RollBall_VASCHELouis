using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;

    public void PlayClickSound()
    {
        clickSound.Play();
    }
}