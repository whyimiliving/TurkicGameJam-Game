using UnityEngine;

public class PlayerMovement : SortingOrderByY
{
    public float moveSpeed = 5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource walkSoundSource;

    [SerializeField] private AudioClip walkSound;

    public Vector2 movement;
    private Vector2 lastDirection = Vector2.down;
    
    public bool canMove = true;
    public static PlayerMovement Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkSoundSource = GetComponent<AudioSource>(); // ✅ Doğru değişkene atandı
    }

    void Update()
    {
        // Input
        if (canMove)
        { 
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }


        // Normalize
        movement = movement.normalized;

        // Sprite yönü
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;

        // Son yönü güncelle
        if (movement != Vector2.zero)
            lastDirection = movement;

        // Blend Tree animasyonu
        Vector2 animDirection = (movement != Vector2.zero) ? movement : lastDirection;
        float animMoveX = Mathf.Abs(animDirection.x);
        float animMoveY = animDirection.y;

        animator.SetFloat("MoveX", animMoveX);
        animator.SetFloat("MoveY", animMoveY);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Hareket
        transform.position += (Vector3)movement * (moveSpeed * Time.deltaTime);

        // 🎧 Yürüme sesi kontrolü
        if (movement.magnitude >= 0.1f)
        {
            if (!walkSoundSource.isPlaying)
            {
                walkSoundSource.clip = walkSound;
                walkSoundSource.loop = true; // yürürken sürekli çalması için
                walkSoundSource.Play();
            }
        }
        else
        {
            if (walkSoundSource.isPlaying)
                walkSoundSource.Stop();
        }

        SetOrder();
    }
}
