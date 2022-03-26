using UnityEngine;

public interface ISpawner
{
    void OnEntityKilled(Tank sender);
    void Spawn(GameObject spawner, Tank spawnTank);
}