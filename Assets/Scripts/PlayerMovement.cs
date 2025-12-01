using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Requirement #3
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;

    bool facingRight = true; // Facing right is true

    private SpriteRenderer spriterenderer; // allows for sprite to flip
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Used for physics movement
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // OnMove will be used by the Player Input component when the WASD or Arrow keys are pressed
    public void OnMove(InputAction.CallbackContext context)
    {
        if (rb != null)
        {
            // Returns a vector with the values -1, 0, or 1 to indicate the direction of movement (x, y)
            Vector2 movement = context.ReadValue<Vector2>();
            rb.linearVelocity = movement * speed;
            playerFlip(movement.x);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void playerFlip(float movX) // flipping Player when positioned left
    {
        if (spriterenderer != null)
        {
            if(movX > 0.01f)
            {
                spriterenderer.flipX = false; // when facing right
            }
            else if(movX < -0.01f)
            {
                spriterenderer.flipX = true; // when facing left
            }
        }
    }

}