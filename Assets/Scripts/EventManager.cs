using System;

public static class EventManager
{
    public static event Action<Tank> EnemyKilled;
    public static event Action PlayerKilled;
    public static event Action<PowerUps, float> PowerUpPickUp;
    public static event Action Victory;
    public static event Action Defeat;

    public static void OnEnemyKilled(Tank tank)
    {
        EnemyKilled?.Invoke(tank);
    }

    public static void OnPlayerKilled()
    {
        PlayerKilled?.Invoke();
    }

    public static void OnPowerUpPickUp(PowerUps powerUp, float duration)
    {
        PowerUpPickUp?.Invoke(powerUp, duration);
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
