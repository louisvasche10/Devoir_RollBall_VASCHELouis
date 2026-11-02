using UnityEngine;
public class TeleportPortal : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (destination == null)
        {
            Debug.LogWarning("Aucune destination assignée au portail.");
            return;
        }

        Rigidbody rb = other.GetComponentInParent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Aucun Rigidbody trouvé sur le joueur.");
            return;
        }

        PlaySoundTeleporter();

        rb.position = destination.position;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void PlaySoundTeleporter()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}