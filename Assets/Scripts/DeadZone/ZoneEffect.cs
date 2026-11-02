using UnityEngine;

public class DangerZoneMovement : MonoBehaviour
{
    [Header("Vitesse")]
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
}