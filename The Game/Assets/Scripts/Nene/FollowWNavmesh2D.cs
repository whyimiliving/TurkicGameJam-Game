using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class FollowWNavmesh2D : SortingOrderByY
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 1f;
    
    private AudioSource walkSoundSource;

    [SerializeField] private AudioClip walkSound;

    private NavMeshAgent agent;
    private Animator animator;
    private SpriteRenderer spriteRendererr;

    private Vector2 lastDirection = Vector2.down;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = distance;

        walkSoundSource = GetComponent<AudioSource>(); // ✅ Doğru değişkene atandı
        animator = GetComponent<Animator>();
        spriteRendererr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        agent.SetDestination(target.position);

        Vector2 velocity = agent.velocity;

        if (velocity.magnitude > 0.01f)
        {
            Vector2 dir = velocity.normalized;
            lastDirection = dir;

            animator.SetFloat("MoveX", Mathf.Abs(dir.x));
            animator.SetFloat("MoveY", dir.y);
            animator.SetFloat("Speed", velocity.sqrMagnitude);

            if (dir.x != 0)
                spriteRendererr.flipX = dir.x < 0;
        }
        else
        {
            animator.SetFloat("MoveX", Mathf.Abs(lastDirection.x));
            animator.SetFloat("MoveY", lastDirection.y);
            animator.SetFloat("Speed", 0);
        }
        
        // 🎧 Yürüme sesi kontrolü
        if (velocity.magnitude >= 0.1f)
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