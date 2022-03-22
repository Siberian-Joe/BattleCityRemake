using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _numbersOfEnemies = 20;
    [SerializeField] private int _numbersOfEnemiesOnMap = 4;
    [SerializeField] private int _numberOfPlayerAttempts = 3;

    public int NumberOfEnemies => _numbersOfEnemies;
    public int NumberOfEnemiesOnMap => _numbersOfEnemiesOnMap;
    public int NumberOfPlayerAttempts => _numberOfPlayerAttempts;

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

    private void OnEnemyKilled(Tank tank)
    {
        _numbersOfEnemies--;

        if (_numbersOfEnemies == 0)
        {
            Victory();
            return;
        }
    }

    private void OnPlayerKilled(Tank tank)
    {
        if (_numberOfPlayerAttempts == 0)
        {
            Defeat();
            return;
        }

        _numberOfPlayerAttempts--;
    }

    private void Victory()
    {
        Debug.Log("You victory!");
    }

    private void Defeat()
    {
        Debug.Log("You defeat!");
    }
}
