using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;

    public void PlaySoundBonus()
    {
        audioSource.Play();
    }
}