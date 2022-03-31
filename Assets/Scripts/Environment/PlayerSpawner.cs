using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerSpawner;
    [SerializeField] private Tank _player;
    [SerializeField] private int _numberOfPlayerAttempts = 3;

    private void Start()
    {
        Spawn(_playerSpawner, _player);
    }

    private void OnEnable()
    {
        EventManager.PlayerKilled += OnEntityKilled;
    }

    private void OnDisable()
    {
        EventManager.PlayerKilled -= OnEntityKilled;
    }

    public void OnEntityKilled()
    {
        if (_numberOfPlayerAttempts <= 0)
        {
            EventManager.OnDefeat();
            return;
        }

        _numberOfPlayerAttempts--;
        Spawn(_playerSpawner, _player);
    }

    public void Spawn(GameObject spawner, Tank spawnTank)
    {
        Instantiate(spawnTank, spawner.transform.position, Quaternion.identity);
    }
}