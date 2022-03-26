using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private AudioClip _movementAudio;

    private Input _input;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private Vector2 _direction;

    private void Awake()
    {
        _input = new Input();
        _rigidbody = GetComponent<Rigidbody>();
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

    public void Move()
    {
        _direction = _input.Movement.Move.ReadValue<Vector2>();

        if (_direction == Vector2.zero)
            return;

        Vector3 moveDirection = new Vector3(_direction.x, 0, _direction.y);

        _rigidbody.MoveRotation(Quaternion.LookRotation(moveDirection, Vector3.up));
        _rigidbody.MovePosition(transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime);

        if (_audioSource.isPlaying == false)
            _audioSource.PlayOneShot(_movementAudio, 0.5f);
    }
}