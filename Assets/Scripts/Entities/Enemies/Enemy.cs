using UnityEngine;

[RequireComponent(typeof(IMovement))]
[RequireComponent(typeof(IShooting))]
public class Enemy : Tank
{
    private IMovement _enemyMovement;
    private IShooting _enemyShooting;

    protected override void OnHited(Tank sender)
    {
        if (sender == this || sender.GetComponent<Enemy>() != null)
            return;

        GetHit();
    }

    protected override void OnKilled()
    {
        EventManager.OnEnemyKilled(this);

        base.OnKilled();
    }

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