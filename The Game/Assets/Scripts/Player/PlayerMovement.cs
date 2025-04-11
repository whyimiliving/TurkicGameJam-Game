using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    private Vector2 movement;
    
    [SerializeField] InputData inputData;
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize (diagonaller hızlı gitmesin)
        movement = movement.normalized;

        // Animator parametreleri
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        UpdateDirectionAnimation(movement);
    }

    void FixedUpdate()
    {
        // Hareket (Rigidbodyn varsa onunla yap)
        transform.position += (Vector3)movement * moveSpeed * Time.fixedDeltaTime;
    }

    void UpdateDirectionAnimation(Vector2 move)
    {
        if (move == Vector2.zero) return;

        string direction = "";

        if (move.y > 0)
        {
            if (move.x > 0) direction = "UpRight";
            else if (move.x < 0) direction = "UpRight"; // Flip'le sol yapacağız
            else direction = "Up";
        }
        else if (move.y < 0)
        {
            if (move.x > 0) direction = "DownRight";
            else if (move.x < 0) direction = "DownRight"; // Flip'le sol yapacağız
            else direction = "Down";
        }
        else
        {
            if (move.x > 0) direction = "Right";
            else if (move.x < 0) direction = "Right"; // Flip'le sol yapacağız
        }

        // FlipX sol yönler için
        if (move.x < 0)
            spriteRenderer.flipX = true;
        else if (move.x > 0)
            spriteRenderer.flipX = false;

        animator.Play(direction);
    }
}
