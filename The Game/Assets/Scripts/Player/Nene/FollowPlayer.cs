using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float stopDistance = 1.5f;
    private NavMeshAgent agent;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 lastDir = Vector2.down;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > stopDistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.ResetPath(); // Fazla yaklaşınca dur
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        Vector2 velocity = agent.velocity;

        if (velocity.magnitude > 0.05f)
            lastDir = velocity.normalized;

        float absX = Mathf.Abs(lastDir.x);
        float absY = Mathf.Abs(lastDir.y);

        // Flip
        if (lastDir.x < 0)
            spriteRenderer.flipX = true;
        else if (lastDir.x > 0)
            spriteRenderer.flipX = false;

        // Animasyon seçimi
        if (velocity.magnitude < 0.05f)
        {
            if (absY > absX)
                animator.Play(lastDir.y > 0 ? "IdleUp" : "IdleDown");
            else
                animator.Play("IdleRight");
        }
        else
        {
            if (absY > absX)
                animator.Play(lastDir.y > 0 ? "WalkUp" : "WalkDown");
            else
                animator.Play("WalkRight");
        }
    }
}