using UnityEngine;
public class MovingTrapForward : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float detectionDistance = 15f;

    private Transform player;
    private bool isMoving = false;

    void Start()
    {
        PlayerMovement playerMovement =
            FindFirstObjectByType<PlayerMovement>();

        if (playerMovement != null)
        {
            player = playerMovement.transform;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        if (!isMoving)
        {
            float distance = Vector3.Distance(transform.position,player.position);

            if (distance <= detectionDistance)
            {
                isMoving = true;
            }
        }

        if (isMoving)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }
}


