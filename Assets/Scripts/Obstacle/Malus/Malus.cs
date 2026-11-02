using UnityEngine;
using UnityEngine.Audio;

public class Malus : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlaySoundMalus()
    {
        audioSource.Play();
    }
}
