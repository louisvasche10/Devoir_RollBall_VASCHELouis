using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Déplacement gauche/droite")]
    [SerializeField] private float horizontalSpeed = 6f;
    [SerializeField] private float horizontalLerpSpeed = 4f;

    [Header("Vitesse vers l'avant")]
    [SerializeField] private float normalSpeed = 15f;
    [SerializeField] private float brakeSpeed = 2f;
    [SerializeField] private float forwardAcceleration = 25f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private PlayerBoost playerBoost;

    private float wallControlTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerBoost = GetComponent<PlayerBoost>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        // Déplacement latéral progressif
        if (wallControlTimer > 0f)
        {
            wallControlTimer -= Time.fixedDeltaTime;

            velocity.x = Mathf.Lerp(velocity.x,0f,horizontalLerpSpeed * Time.fixedDeltaTime);
        }
        else
        {
            float targetHorizontalSpeed =
                playerInput.HorizontalInput * horizontalSpeed;

            velocity.x = Mathf.Lerp(
                velocity.x,targetHorizontalSpeed,horizontalLerpSpeed * Time.fixedDeltaTime);
        }

        // Vitesse sur z
        float currentSpeed = normalSpeed;

        if (playerInput.BrakeInput)
        {
            currentSpeed = brakeSpeed;
        }

        // Accélération progressive 
        velocity.z = Mathf.MoveTowards(velocity.z,currentSpeed,forwardAcceleration * Time.fixedDeltaTime);

        rb.linearVelocity = velocity;
    }

    public void BlockHorizontalControl(float duration)
    {
        wallControlTimer = duration;
    }

    public void ResetPlayer(Vector3 respawnPosition)
    {
        transform.position = respawnPosition;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        wallControlTimer = 0f;
        playerBoost.ResetBoost();
    }
}
