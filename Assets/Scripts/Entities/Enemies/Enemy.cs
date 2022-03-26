using UnityEngine;

[RequireComponent(typeof(IMovement))]
[RequireComponent(typeof(IShooting))]
public class Enemy : MonoBehaviour
{
    private IMovement _enemyMovement;
    private IShooting _enemyShooting;

    private void Awake()
    {
        _enemyMovement = GetComponent<IMovement>();
        _enemyShooting = GetComponent<IShooting>();
    }

    private void Start()
    {
        StartCoroutine(_enemyShooting.Shooting());
    }

    private void Update()
    {
        _enemyMovement.Move();
    }
}