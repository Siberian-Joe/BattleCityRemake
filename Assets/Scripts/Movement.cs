using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2;

    private Input _input;
    private Rigidbody _rigidbody;

    private Vector2 _directionKeyboard;

    private void Awake()
    {
        _input = new Input();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();   
    }

    void Update()
    {
        _directionKeyboard = _input.Movement.Move.ReadValue<Vector2>();

        Move(_directionKeyboard);
    }

    private void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        Vector3 moveDirection = new Vector3(direction.x, 0,direction.y);

        _rigidbody.MoveRotation(Quaternion.LookRotation(moveDirection, Vector3.up));
        _rigidbody.MovePosition(transform.position + moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }
}
