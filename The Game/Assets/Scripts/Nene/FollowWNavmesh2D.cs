using UnityEngine;
using UnityEngine.AI;

public class FollowWNavmesh2D : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
