using UnityEngine;
public class MovingTrapSideways : MonoBehaviour
{
    public float distance = 3f;
    public float speed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance * 2) - distance;

        transform.position = startPosition + Vector3.right * movement;
    }
}