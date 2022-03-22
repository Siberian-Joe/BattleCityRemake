using System;

public static class EventManager
{
    public static event Action<Tank> EnemyKilled;
    public static event Action EnemySpawned;
    public static event Action<Tank> PlayerKilled;
    public static event Action PlayerSpawned;

    public static void OnEnemyKilled(Tank tank)
    {
        EnemyKilled?.Invoke(tank);
    }

    public static void OnEnemySpawned()
    {
        EnemySpawned?.Invoke();
    }

    public static void OnPlayerKilled(Tank tank)
    {
        PlayerKilled?.Invoke(tank);
    }

    public static void OnPlayerSpawned()
    {
        PlayerSpawned?.Invoke();
    }
}
