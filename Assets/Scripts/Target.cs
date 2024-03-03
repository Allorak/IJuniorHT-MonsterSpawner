using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 2;

    private int _currentWayPointIndex = 0;

    private void Start()
    {
        if(_wayPoints.Length == 0)
            Debug.LogWarning($"No waypoints set for {gameObject.name}");
    }

    private void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 wayPointPosition = _wayPoints[_currentWayPointIndex].position;
        var stepDistance = _speed * Time.deltaTime;
        
        var newPosition = Vector2.MoveTowards(currentPosition, wayPointPosition, stepDistance);

        if (Vector2.Distance(newPosition, transform.position) == 0)
            _currentWayPointIndex = ++_currentWayPointIndex % _wayPoints.Length;
        
        transform.position = newPosition;
    }
}
