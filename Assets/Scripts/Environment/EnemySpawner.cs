using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemySpawners;
    [SerializeField] private List<Tank> _typesOfTanks;
    [SerializeField] private List<int> _numbersOfTanks;

    private int _spawnCounter = 0;
    private Dictionary<int, Tank> _spawnedTanks = new Dictionary<int, Tank>();
    private List<int> _spawnedNumbersOfTanks = new List<int>();

    private void Start()
    {
        _spawnedNumbersOfTanks = new List<int>(_numbersOfTanks);

        for (int i = 0; i < _typesOfTanks.Count; i++)
        {
            if (_numbersOfTanks[i] == 0)
                continue;

            int number = _numbersOfTanks[i];
            for (int j = 0; j < number; j++)
            {
                if (_enemySpawners.Count != _spawnCounter)
                {
                    Spawn(_enemySpawners[_spawnCounter], _typesOfTanks[i]);

                    _spawnedNumbersOfTanks[i]--;
                    _spawnCounter++;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void OnEnable()
    {
        EventManager.EnemyKilled += OnEntityKilled;
    }

    private void OnDisable()
    {
        EventManager.EnemyKilled -= OnEntityKilled;
    }

    public void OnEntityKilled(Tank sender)
    {
        for (int i = 0; i < _typesOfTanks.Count; i++)
        {
            if (_spawnedNumbersOfTanks[i] == 0)
                continue;

            Spawn(_enemySpawners[Random.Range(0, _typesOfTanks.Count)], _typesOfTanks[i]);

            _spawnedNumbersOfTanks[i]--;

            break;
        }

        if (_spawnedTanks.TryGetValue(sender.GetInstanceID(), out Tank currentTank))
            _numbersOfTanks[_typesOfTanks.IndexOf(currentTank)]--;

        if (IsNumbersOfTanksEmpty(_numbersOfTanks))
            EventManager.OnVictory();
    }

    public void Spawn(GameObject spawner, Tank spawnTank)
    {
        Tank tank = Instantiate(spawnTank, spawner.transform.position, Quaternion.identity);

        _spawnedTanks.Add(tank.GetInstanceID(), spawnTank);
    }

    private bool IsNumbersOfTanksEmpty(List<int> numbersOfTanks)
    {
        for (int i = 0; i < numbersOfTanks.Count; i++)
        {
            if (numbersOfTanks[i] != 0)
                return false;
        }

        return true;
    }
}