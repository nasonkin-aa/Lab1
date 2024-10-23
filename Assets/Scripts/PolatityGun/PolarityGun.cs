using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PolarityGun : MonoBehaviour
{
    public Transform Gun;
    private Vector2 _direction;
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = mousePos - (Vector2)Gun.position;
        Gun.right = _direction;

    }
}
