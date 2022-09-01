using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;

    public static GameManager Instance
    {
        get => _gameManager;
        set => _gameManager = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private int _scoreToWin = 5;

    public int ScoreToWin => _scoreToWin;

    [SerializeField] private UIController _uiController;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public int ScorePlayer1
    {
        get => scorePlayer1;
        set => scorePlayer1 = value;
    }

    public int ScorePlayer2
    {
        get => scorePlayer2;
        set => scorePlayer2 = value;
    }

    private bool _gameOver;

    public bool GameOver
    {
        get => _gameOver;
        set
        {
            _gameOver = value;
            _uiController.ShowGameOverScreen();
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Pong");
    }
}
