using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerShooting : MonoBehaviour, IShooting
{
    [SerializeField] private Shell _shellObject;
    [SerializeField] private float _speedShell = 7;
    [SerializeField] private float _fireRatePerMinute = 75;
    [SerializeField] private GameObject _barrel;
    [SerializeField] private AudioClip _shootingAudio;

    private Input _input;
    private AudioSource _audioSource;

    private readonly float _ONE_MINUTE = 60;

    private void Awake()
    {
        _input = new Input();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitUntil(() => _input.Shooting.Shoot.IsPressed() == true);

            Shoot();

            yield return new WaitForSeconds(_ONE_MINUTE / _fireRatePerMinute);
        }
    }

    private void Shoot()
    {
        Shell shell = Instantiate(_shellObject, _barrel.transform.position, transform.rotation);
        shell.GetComponent<Rigidbody>().AddForce(shell.transform.forward * _speedShell, ForceMode.Impulse);
        shell.Sender = gameObject.GetComponent<Tank>();

        _audioSource.PlayOneShot(_shootingAudio, 0.1f);
    }
}
