using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _rangeRandomPoint = 5.0f;
    [SerializeField] private float _randomShootingInterval = 1;
    [SerializeField] private float _speedShell = 7;
    [SerializeField] private float _fireRate = 10;
    [SerializeField] private Shell _shellObject;
    [SerializeField] private GameObject _barrel;

    private Shell _shell;
    private float _timer;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _agent.avoidancePriority = Random.Range(0, 100);

        StartCoroutine(RandomShooting());
    }

    private void Update()
    {
        if (_agent.remainingDistance <= 1 || _agent.hasPath == false)
            SetRandomPoint();
    }

    private void FixedUpdate()
    {
        RaycastHit raycastHit;
        if ((Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity) &&
            raycastHit.collider.gameObject != null &&
            raycastHit.collider.GetComponent<Player>() != null))
            Shooting();
    }

    private IEnumerator RandomShooting()
    {
        while(true)
        {
            Shooting();
            yield return new WaitForSeconds(_randomShootingInterval);
        }
    }

    private void Shooting()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer < 1 / _fireRate || _shell != null)
            return;

        _timer = 0;

        _shell = Instantiate(_shellObject, _barrel.transform.position, transform.rotation);
        _shell.GetComponent<Rigidbody>().AddForce(_shell.transform.forward * _speedShell, ForceMode.Impulse);
    }

    private void SetRandomPoint()
    {
        NavMeshHit navMeshHit = new NavMeshHit();
        NavMeshPath path = new NavMeshPath();

        while (path.status != NavMeshPathStatus.PathComplete)
        {
            bool foundPosition = NavMesh.SamplePosition(transform.position + Random.insideUnitSphere * _rangeRandomPoint, out navMeshHit, _rangeRandomPoint, NavMesh.AllAreas);

            if (!foundPosition)
                continue;

            _agent.CalculatePath(navMeshHit.position, path);
        }

        _agent.SetDestination(navMeshHit.position);
    }
}
