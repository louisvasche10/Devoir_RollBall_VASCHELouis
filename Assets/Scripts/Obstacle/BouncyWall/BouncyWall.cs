using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    [SerializeField] private float minimumLateralSpeed = 5f;
    [SerializeField] private float controlLockDuration = 0.7f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb == null) return;

        Vector3 velocity = rb.linearVelocity;
        Vector3 wallNormal = collision.contacts[0].normal;

        if (Mathf.Abs(wallNormal.x) < 0.5f) return;

        float wallSide = Mathf.Sign(wallNormal.x);
        velocity.x = -wallSide * Mathf.Max(Mathf.Abs(velocity.x), minimumLateralSpeed);
        rb.linearVelocity = velocity;

        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null) playerMovement.BlockHorizontalControl(controlLockDuration);
    }
}
