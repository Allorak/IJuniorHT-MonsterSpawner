using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2;
    private Vector2 _movementDirection;

    private void Update()
    {
        Vector2 step = _speed * Time.deltaTime * _movementDirection;
        transform.Translate(step);
    }

    public void SetDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
