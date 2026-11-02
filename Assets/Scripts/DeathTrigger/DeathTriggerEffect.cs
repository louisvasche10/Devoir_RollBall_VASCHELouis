using UnityEngine;

public class DeathTriggerEffect : MonoBehaviour
{
    private bool hasTriggeredDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggeredDeath)
        {
            return;
        }

        PlayerMovement playerMovement =
            other.GetComponentInParent<PlayerMovement>();

        if (playerMovement == null)
        {
            return;
        }

        DeathManager deathManager =
            FindFirstObjectByType<DeathManager>();


        hasTriggeredDeath = true;
        deathManager.AddDeath();
    }
}


