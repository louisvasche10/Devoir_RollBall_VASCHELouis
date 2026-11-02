using UnityEngine;

public class CanonController : MonoBehaviour
{
    [Header("Canon Settings")]
    [SerializeField] private GameObject canonBallPrefab;
    [SerializeField] private Transform canonBallSpawnPoint;
    [SerializeField] private float fireRate = 2f;

    void Start()
    {
        InvokeRepeating("FireCanonBall", 0f, fireRate);
    }

    void FireCanonBall()
    {
        Instantiate(canonBallPrefab, canonBallSpawnPoint.position, canonBallSpawnPoint.rotation);
    }
}

