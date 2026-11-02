using UnityEngine;

public class CanonBall : MonoBehaviour
{
    [Header("Canon Ball Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float directionX = -1f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = new Vector3(directionX * speed, 0f, 0f);
        Destroy(gameObject, 5f);
    }

}
