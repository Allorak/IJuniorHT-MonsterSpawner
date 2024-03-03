using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnOffsetDistance;
    [SerializeField] private Target _movingTarget;

    public void Spawn()
    {
        if (_template is null)
            return;

        var enemy = Instantiate(_template, GetSpawnPosition(), Quaternion.identity);
        enemy.SetTarget(_movingTarget);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 offset = Random.insideUnitCircle * _spawnOffsetDistance;
        return transform.position + offset;
    }
}
