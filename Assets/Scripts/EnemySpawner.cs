using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private int _numbersOfEnemies = 5;

    private GameObject _currentObject;

    private void Start()
    {
        SpawnNewObject();
    }

    private void OnDestroy()
    {
        Destroy(_currentObject);
    }
    private void OnDestroyObject()
    {
        _currentObject.GetComponent<Enemy>().DestroyEvent -= OnDestroyObject;

        SpawnNewObject();
    }

    private void SpawnNewObject()
    {
        if (_numbersOfEnemies > 0)
        {
            _currentObject = Instantiate(_spawnObject, transform.position, Quaternion.identity);
            _currentObject.GetComponent<Enemy>().DestroyEvent += OnDestroyObject;
            _numbersOfEnemies--;
        }
    }
}
