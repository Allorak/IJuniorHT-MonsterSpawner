using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;

    private SpawnPoint[] _spawnPoints;
    private float _timeSinceLastSpawn = 0;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn < _spawnRate)
            return;

        _timeSinceLastSpawn = 0;
        SelectRandomSpawnPoint()?.Spawn();
    }

    private SpawnPoint SelectRandomSpawnPoint()
    {
        return _spawnPoints.Length == 0
            ? null
            : _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}
