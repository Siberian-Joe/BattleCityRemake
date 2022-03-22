public class PlayerSpawner : Spawner
{
    protected override int GetNumbersOfEntities(LevelManager levelManager) => levelManager.NumberOfPlayerAttempts;

    protected override void OnEntitySpawned() => EventManager.OnPlayerSpawned();
}