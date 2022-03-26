using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour, IShooting
{
    [SerializeField] private float _randomShootingInterval = 15;
    [SerializeField] private float _speedShell = 7;
    [SerializeField] private float _fireRatePerMinute = 75;
    [SerializeField] private Shell _shellObject;
    [SerializeField] private GameObject _barrel;

    private bool _isShooting;

    private readonly float _ONE_MINUTE = 60;

    private void Start()
    {
        StartCoroutine(RandomShooting());
    }

    public IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitUntil(() => (IsPlayerDetected()) || _isShooting == true);

            Shoot();

            yield return new WaitForSeconds(_ONE_MINUTE / _fireRatePerMinute);
        }
    }

    private void Shoot()
    {
        Shell shell = Instantiate(_shellObject, _barrel.transform.position, transform.rotation);
        shell.GetComponent<Rigidbody>().AddForce(shell.transform.forward * _speedShell, ForceMode.Impulse);
        shell.Sender = gameObject.GetComponent<Tank>();
    }

    private bool IsPlayerDetected()
    {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit, Mathf.Infinity) && raycastHit.collider.gameObject != null && raycastHit.collider.GetComponent<Player>() != null;
    }

    private IEnumerator RandomShooting()
    {
        while (true)
        {
            yield return new WaitUntil(() => Random.Range(0, 100) % 2 == 0);

            _isShooting = true;

            yield return new WaitForSeconds(3);

            _isShooting = false;

            yield return new WaitForSeconds(_randomShootingInterval);
        }
    }
}