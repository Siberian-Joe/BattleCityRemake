using UnityEngine;

[RequireComponent(typeof(IMovement))]
[RequireComponent(typeof(IShooting))]
public class Player : MonoBehaviour
{
    private IMovement _playerMovement;
    private IShooting _playerShooting;

    private void Awake()
    {
        _playerMovement = GetComponent<IMovement>();
        _playerShooting = GetComponent<IShooting>();
    }

    private void Start()
    {
        StartCoroutine(_playerShooting.Shooting());
    }

    void FixedUpdate()
    {
        _playerMovement.Move();
    }
}
