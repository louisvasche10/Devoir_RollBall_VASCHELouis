using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float groundCheckDistance = 0.8f;

    public static int JumpCount = 0;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount > 0 && IsGrounded())
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }

    private void Jump()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.y = jumpForce;
        rb.linearVelocity = velocity;

        JumpCount = JumpCount - 1;
    }

    public static void AddJump()
    {
        JumpCount = JumpCount + 1;
    }
    public static void ResetJumps()
    {
        JumpCount = 0;
    }

}