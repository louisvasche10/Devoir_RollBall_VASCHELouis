using UnityEngine;
public class AcceleratorEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBoost playerBoost = other.GetComponent<PlayerBoost>();

            if (playerBoost != null)
            {
                PlaySoundAccelerator();playerBoost.ActivateBoost(); Destroy(gameObject);
            }
        }
    }

    public void PlaySoundAccelerator()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}