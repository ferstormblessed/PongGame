using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _ballRigidbody2D;
    [SerializeField] private float _initialSpeed;
    [SerializeField] private float _velocityMultiplier;
    [SerializeField] private UIController _uiController;
    private void Start()
    {
        Launch();
    }

    private void Launch()
    {
        // Get a random integer from 0 to 1, if it's 0 xVel equals 1 else it equals -1
        float xVel = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVel = Random.Range(0, 2) == 0 ? 1 : -1;
        _ballRigidbody2D.velocity = new Vector2(xVel, yVel) * _initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            _ballRigidbody2D.velocity *= _velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeftGoal"))
        {
            GameManager.Instance.ScorePlayer2++;
            _uiController.UpdateScorePlayer2(GameManager.Instance.ScorePlayer2);
            IsGameOver();
            transform.position = Vector3.zero;
            _ballRigidbody2D.velocity = Vector2.zero;
            Launch();
        }

        if (col.CompareTag("RightGoal"))
        {
            GameManager.Instance.ScorePlayer1++;
            _uiController.UpdateScorePlayer1(GameManager.Instance.ScorePlayer1);
            IsGameOver();
            transform.position = Vector3.zero;
            _ballRigidbody2D.velocity = Vector2.zero;
            Launch();
        }
    }

    private void IsGameOver()
    {

        if (GameManager.Instance.ScorePlayer1 == GameManager.Instance.ScoreToWin)
        {
            _uiController.UpdateWinnerText("1");
            GameManager.Instance.GameOver = true;
        }
        
        if (GameManager.Instance.ScorePlayer2 == GameManager.Instance.ScoreToWin)
        {
            _uiController.UpdateWinnerText("2");
            GameManager.Instance.GameOver = true;
        }
    }
}
