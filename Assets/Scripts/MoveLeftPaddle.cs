using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MoveLeftPaddle : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _moveDirection;

    [SerializeField] private BoxCollider2D _paddleBound;
    [SerializeField] private BoxCollider2D _topBound;
    [SerializeField] private BoxCollider2D _bottomBound;
    private Bounds tBounds;
    private Bounds bBounds;

    private void Start()
    {
        tBounds = _topBound.bounds;
        bBounds = _bottomBound.bounds;
    }

    private void Update()
    {
        Bounds pBounds = _paddleBound.bounds;
        
        if (Input.GetKey(KeyCode.W) && pBounds.max.y <= tBounds.min.y)
        {
            _moveDirection.y = _speed;
        }
        else if (Input.GetKey(KeyCode.S) && pBounds.min.y >= bBounds.max.y)
        {
            _moveDirection.y = -_speed;
        }
        else
        {
            _moveDirection.y = 0;
        }

        transform.position += _moveDirection * Time.deltaTime;
    }
}
