using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool BoostInput { get; private set; }
    public bool BrakeInput { get; private set; }

    private void Update()
    {
        HorizontalInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            HorizontalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            HorizontalInput = -1f;
        }

        BoostInput = Input.GetKey(KeyCode.W);
        BrakeInput = Input.GetKey(KeyCode.S);
    }
}
