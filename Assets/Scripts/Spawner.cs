using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;

    private SpawnPoint[] _spawnPoints;
    private float _timeSinceLastSpawn = 0;
    private int _currentSpawnPointIndex = 0;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        if (_spawnPoints.Length == 0)
            Debug.LogWarning("No spawn points found");
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn < _spawnRate)
            return;

        _timeSinceLastSpawn = 0;

        if (_spawnPoints.Length == 0)
            return;

        _spawnPoints[_currentSpawnPointIndex].Spawn();
        _currentSpawnPointIndex = (_currentSpawnPointIndex + 1) % _spawnPoints.Length;
    }
}
