using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _shellObject;
    [SerializeField] private float _speedShell = 7;
    [SerializeField] private float _fireRate = 10;
    [SerializeField] private GameObject _barrel;

    private Input _input;

    private GameObject _shell;
    private float _timer;

    private void Awake()
    {
        _input = new Input();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer < 1 / _fireRate || _input.Shooting.Shoot.IsPressed() == false || _shell != null)
            return;

        _timer = 0;

        _shell = Instantiate(_shellObject, _barrel.transform.position, transform.rotation);
        _shell.GetComponent<Rigidbody>().AddForce(_shell.transform.forward * _speedShell, ForceMode.Impulse);
    }
}
