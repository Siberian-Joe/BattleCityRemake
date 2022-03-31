using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    private Input _input;

    public Vector2 MovementInputVector { get; private set; }
    public bool IsShooting { get; private set; }

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
        GetInputMovement();
        GetShootingInput();
    }

    private void GetInputMovement()
    {
        MovementInputVector = _input.Movement.Move.ReadValue<Vector2>();
    }

    private void GetShootingInput()
    {
        IsShooting = _input.Shooting.Shoot.IsPressed();
    }
}
