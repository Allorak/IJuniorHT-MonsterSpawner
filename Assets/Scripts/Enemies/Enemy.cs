using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float Speed = 2;

    private const float ReachDistance = 0.1f;
    
    private Target _target;
    private Vector2 _movementDirection;

    private void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = _target.transform.position;
        var stepDistance = Speed * Time.deltaTime;
        
        var newPosition = Vector2.MoveTowards(currentPosition, targetPosition, stepDistance);
        transform.position = newPosition;

        var distanceToTarget = Vector2.Distance(newPosition, targetPosition);
        
        if(distanceToTarget <= ReachDistance)
            Destroy(gameObject);
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }
}
