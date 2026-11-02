using UnityEngine;
using System.Collections;

public class PlayerBoostSpace : MonoBehaviour
{
    [Header("Boost Settings")]
    [SerializeField] private float boostForce = 15f;
    [SerializeField] private float boostDuration = 2f;
    [SerializeField] private float rechargeDuration = 3f;

    private Rigidbody rb;
    private bool isBoosting = false;
    private bool isRecharging = false;
    private float boostAmount = 1f;

    public float BoostAmount
    {
        get { return boostAmount; }
    }

    public bool IsBoosting
    {
        get { return isBoosting; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isBoosting && !isRecharging)
        {
            StartCoroutine(Boost());
        }
    }

    private IEnumerator Boost()
    {
        isBoosting = true;
        boostAmount = 0f;

        float originalSpeed = rb.linearVelocity.z;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, originalSpeed + boostForce);

        yield return new WaitForSeconds(boostDuration);

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, originalSpeed);
        isBoosting = false;
        isRecharging = true;

        float elapsed = 0f;

        while (elapsed < rechargeDuration)
        {
            elapsed = elapsed + Time.deltaTime;
            boostAmount = Mathf.Clamp01(elapsed / rechargeDuration);
            yield return null;
        }

        boostAmount = 1f;
        isRecharging = false;
    }

    public void ResetBoost()
    {
        StopAllCoroutines();
        isBoosting = false;
        isRecharging = false;
        boostAmount = 1f;
    }
}