using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private AudioClip _movementAudio;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }


    public void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);

        _rigidbody.MoveRotation(Quaternion.LookRotation(moveDirection, Vector3.up));
        _rigidbody.MovePosition(transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime);

        if (_audioSource.isPlaying == false)
            _audioSource.PlayOneShot(_movementAudio, 0.5f);
    }
}