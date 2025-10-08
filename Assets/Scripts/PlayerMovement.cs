using UnityEngine;
using UnityEngine.InputSystem;

// Requirement #3
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Used for physics movement
        rb = GetComponent<Rigidbody2D>();
    }

    // OnMove will be used by the Player Input component when the WASD or Arrow keys are pressed
    public void OnMove(InputAction.CallbackContext context)
    {
        // Returns a vector with the values -1, 0, or 1 to indicate the direction of movement (x, y)
        Vector2 movement = context.ReadValue<Vector2>();
        rb.linearVelocity = movement * speed;
    }
}
