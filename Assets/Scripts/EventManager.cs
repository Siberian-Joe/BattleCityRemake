using System;

public static class EventManager
{
    public static event Action<Tank> EnemyKilled;
    public static event Action<Tank> PlayerKilled;
    public static event Action Victory;
    public static event Action Defeat;


    public static void OnEnemyKilled(Tank tank)
    {
        EnemyKilled?.Invoke(tank);
    }

    public static void OnPlayerKilled(Tank tank)
    {
        PlayerKilled?.Invoke(tank);
    }

    public static void OnVictory()
    {
        Victory?.Invoke();
    }

    public static void OnDefeat()
    {
        Defeat?.Invoke();
    }
}
