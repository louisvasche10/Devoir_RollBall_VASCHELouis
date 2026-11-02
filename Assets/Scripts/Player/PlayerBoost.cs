using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    [Header("Accélérateur")]
    [SerializeField] private float acceleratorBoostForce = 78f;
    [SerializeField] private float acceleratorBoostDuration = 4f;

    private Rigidbody rb;
    private float boostTimer;

    public bool IsBoosting { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (boostTimer > 0f)
        {
            boostTimer -= Time.deltaTime;

            if (boostTimer <= 0f)
            {
                IsBoosting = false;
            }
        }
    }

    public void ActivateBoost()
    {
        IsBoosting = true;
        boostTimer = acceleratorBoostDuration;

        rb.AddForce(
            Vector3.forward * acceleratorBoostForce,
            ForceMode.Impulse
        );
    }

    public void ResetBoost()
    {
        IsBoosting = false;
        boostTimer = 0f;
    }
}
