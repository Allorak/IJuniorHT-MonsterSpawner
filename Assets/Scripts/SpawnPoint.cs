using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnOffsetDistance;

    public void Spawn()
    {
        if (_template is null)
            return;

        Instantiate(_template, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        Vector3 offset = Random.insideUnitCircle * _spawnOffsetDistance;
        return transform.position + offset;
    }
}
