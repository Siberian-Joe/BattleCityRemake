using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<PowerUp> _powerUps;
    [SerializeField] private float _spawnDelay = 15;
    [SerializeField] private float _rangeRandomPoint = 30;
    [SerializeField] private float _numberOfPowerUps = 3;

    private void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    private IEnumerator SpawnPowerUp()
    {
        while(_numberOfPowerUps != 0)
        {
            yield return new WaitForSeconds(_spawnDelay);
            
            bool foundPosition = NavMesh.SamplePosition(transform.position + Random.insideUnitSphere * _rangeRandomPoint, out NavMeshHit navMeshHit, _rangeRandomPoint, NavMesh.AllAreas);

            if (foundPosition == false)
                continue;

            PowerUp powerUp = _powerUps[Random.Range(0, _powerUps.Count)];

            Instantiate(powerUp, navMeshHit.position + powerUp.transform.position, powerUp.transform.rotation);

            _numberOfPowerUps--;
        }
    }
}
