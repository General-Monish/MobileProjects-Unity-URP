using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick; // Reference to the joystick script
    public float speed = 10f; // Movement speed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from the joystick
        float hor = joystick.inputDirection.x;
        float ver = joystick.inputDirection.y;

        // Calculate movement direction
        Vector3 direction = new Vector3(-hor, 0, -ver);

        // Move the player using Rigidbody
        rb.AddForce(direction * speed, ForceMode.Force);
    }
}
