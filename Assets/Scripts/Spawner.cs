using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;

    private SpawnPoint[] _spawnPoints;
    private int _currentSpawnPointIndex = 0;
    private bool _isActive = true;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        if (_spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points found");
            return;
        }

        StartCoroutine(nameof(SpawnRepeatedly));
    }

    private IEnumerator SpawnRepeatedly()
    {
        var wait = new WaitForSeconds(_spawnRate);

        while (_isActive)
        {
            SpawnEnemy();
            yield return wait;
        }
    }

    private void SpawnEnemy()
    {
        var enemyMovingDirection = Random.insideUnitCircle.normalized;
        
        _spawnPoints[_currentSpawnPointIndex].Spawn(enemyMovingDirection);
        _currentSpawnPointIndex = ++_currentSpawnPointIndex % _spawnPoints.Length;
    }
}
