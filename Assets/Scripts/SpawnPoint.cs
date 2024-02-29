using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnOffsetDistance;

    public void Spawn(Vector2 movingDirection)
    {
        if (_template is null)
            return;

        var enemy = Instantiate(_template, GetSpawnPosition(), Quaternion.identity);
        enemy.SetDirection(movingDirection);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 offset = Random.insideUnitCircle * _spawnOffsetDistance;
        return transform.position + offset;
    }
}
