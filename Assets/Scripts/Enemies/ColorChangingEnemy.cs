using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChangingEnemy : Enemy
{
    private SpriteRenderer _spriteRenderer;
    private float _colorChangeRate = 2;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(nameof(ChangeColorRepeatedly));
    }

    private IEnumerator ChangeColorRepeatedly()
    {
        var wait = new WaitForSeconds(_colorChangeRate);

        while (isActiveAndEnabled)
        {
            ChangeColor();
            yield return wait;
        }
    }

    private void ChangeColor()
    {
        _spriteRenderer.color = Random.ColorHSV();
    }
}
