public class EnemySpawner : Spawner
{
    protected override int GetNumbersOfEntities(LevelManager levelManager) => levelManager.NumberOfEnemies - levelManager.NumberOfEnemiesOnMap;

    protected override void OnEntitySpawned() => EventManager.OnEnemySpawned();
}
