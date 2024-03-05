using UnityEngine;

public class TeleportingEnemy : Enemy
{
    [SerializeField] private float _teleportDistance;
    [SerializeField] private float _teleportCooldown;
    [SerializeField] private float _randomTeleportOffset;
    
    private float _lastTeleportTime = 0;
    
    protected override Vector2 GetNewPosition(Vector2 currentPosition, Vector2 targetPosition)
    {
        if (Time.time - _lastTeleportTime < _teleportCooldown)
            return currentPosition;

        _lastTeleportTime = Time.time;
        
        Vector2 movementDirection = (targetPosition - currentPosition).normalized;
        Vector2 teleportCenter = currentPosition + movementDirection * _teleportDistance;

        float distanceToTeleport = Vector2.Distance(teleportCenter, currentPosition);
        float distanceToTarget = Vector2.Distance(targetPosition, currentPosition);
        
        if (distanceToTeleport > distanceToTarget)
            teleportCenter = targetPosition;
        
        return teleportCenter + Random.insideUnitCircle * _randomTeleportOffset;
    }
}
