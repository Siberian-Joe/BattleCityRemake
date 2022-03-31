using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _rangeRandomPoint = 5.0f;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _agent.avoidancePriority = Random.Range(0, 100);
    }

    public void Move()
    {
        if (_agent.remainingDistance > 1 && _agent.hasPath == true)
            return;

        NavMeshHit navMeshHit = new NavMeshHit();
        NavMeshPath path = new NavMeshPath();

        while (path.status != NavMeshPathStatus.PathComplete)
        {
            bool foundPosition = NavMesh.SamplePosition(transform.position + Random.insideUnitSphere * _rangeRandomPoint, out navMeshHit, _rangeRandomPoint, NavMesh.AllAreas);

            if (foundPosition == false)
                continue;

            _agent.CalculatePath(navMeshHit.position, path);
        }

        _agent.SetDestination(navMeshHit.position);
    }
}