using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float ReachDistance = 0.1f;
    
    [SerializeField] private float _speed = 2;
    
    private Target _target;

    private void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = _target.transform.position;
        
        var distanceToTarget = Vector2.Distance(currentPosition, targetPosition);
        
        if(distanceToTarget <= ReachDistance)
            Destroy(gameObject);
        
        transform.position = GetNewPosition(currentPosition, targetPosition);
    }

    protected virtual Vector2 GetNewPosition(Vector2 currentPosition, Vector2 targetPosition)
    {
        var stepDistance = _speed * Time.deltaTime;
        return Vector2.MoveTowards(currentPosition, targetPosition, stepDistance);
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }
}
