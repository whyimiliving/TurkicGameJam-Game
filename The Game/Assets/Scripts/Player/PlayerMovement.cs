using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down; // varsayılan başlangıç yönü

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize
        movement = movement.normalized;

        // Sprite yönü
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;

        // Son yönü güncelle (hareket varsa)
        if (movement != Vector2.zero)
            lastDirection = movement;

        // Blend Tree’ye yön bilgisi gönder
        Vector2 animDirection = (movement != Vector2.zero) ? movement : lastDirection;

        // SADECE animasyon yönü sağ gibi gösterilmeli çünkü sol yönleri flipX ile çözüyoruz
        float animMoveX = Mathf.Abs(animDirection.x); // Flip'e göre pozitif gönder
        float animMoveY = animDirection.y; // Y değeri negatif/pozitif kalmalı

        animator.SetFloat("MoveX", animMoveX);
        animator.SetFloat("MoveY", animMoveY);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Hareket ettir
        transform.position += (Vector3)movement * (moveSpeed * Time.deltaTime);
    }
}