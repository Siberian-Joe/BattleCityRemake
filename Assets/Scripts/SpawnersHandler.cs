using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
[RequireComponent(typeof(PlayerSpawner))]
public class SpawnersHandler : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private PlayerSpawner _playerSpawner;

    private void Awake()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
        _playerSpawner = GetComponent<PlayerSpawner>();
    }

    private void OnEnable()
    {
        EventManager.EnemyKilled += OnEnemyKilled;
        EventManager.PlayerKilled += OnPlayerKilled;
    }

    private void OnDisable()
    {
        EventManager.EnemyKilled -= OnEnemyKilled;
        EventManager.PlayerKilled -= OnPlayerKilled;
    }

    private void OnEnemyKilled(Tank sender)
    {
        _enemySpawner.OnEntityKilled(sender);
    }

    private void OnPlayerKilled(Tank sender)
    {
        _playerSpawner.OnEntityKilled(sender);
    }
}
