using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class FollowWNavmesh2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 1f;

    private NavMeshAgent agent;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 lastDirection = Vector2.down;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = distance;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        agent.SetDestination(target.position);
    }

    void Update()
    {
        if (target == null) return;
        
      
        Vector2 direction = (agent.velocity).normalized;

        if (direction.magnitude > 0.1f)
        {
            lastDirection = direction;

            
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetFloat("MoveX", lastDirection.x);
            animator.SetFloat("MoveY", lastDirection.y);
            animator.SetBool("IsMoving", false);
        }

      
        if (direction.x != 0)
            spriteRenderer.flipX = direction.x < 0;
    }
}