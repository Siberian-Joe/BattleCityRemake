using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Tank _spawnTank;
    [SerializeField] private LevelManager _levelManager;

    private Tank _currentObject;

    private void Start()
    {
        SpawnNewObject(_currentObject);
    }

    private void OnEnable()
    {
        EventManager.PlayerKilled += OnEntityKilled;
        EventManager.EnemyKilled += OnEntityKilled;
    }

    private void OnDisable()
    {
        EventManager.PlayerKilled -= OnEntityKilled;
        EventManager.EnemyKilled -= OnEntityKilled;
    }

    private void OnEntityKilled(Tank tank)
    {
        SpawnNewObject(tank);
    }

    private void SpawnNewObject(Tank tank)
    {
        if (GetNumbersOfEntities(_levelManager) > 0 && (_currentObject == null || _currentObject.gameObject == tank.gameObject))
        {
            _currentObject = Instantiate(_spawnTank, transform.position, Quaternion.identity);

            OnEntitySpawned();
        }
    }

    protected abstract int GetNumbersOfEntities(LevelManager levelManager);
    protected abstract void OnEntitySpawned();
}
