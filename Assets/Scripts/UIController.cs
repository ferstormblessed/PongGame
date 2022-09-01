using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scorePlayer1Text;
    [SerializeField] private TMP_Text _scorePlayer2Text;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TMP_Text _winnerText;
    [SerializeField] private GameObject _startScene;
    [SerializeField] private GameObject _ball;

    public void UpdateScorePlayer1(int newScore)
    {
        _scorePlayer1Text.text = newScore.ToString();
    }
    
    public void UpdateScorePlayer2(int newScore)
    {
        _scorePlayer2Text.text = newScore.ToString();
    }

    public void UpdateWinnerText(string player)
    {
        _winnerText.text = "WINNER PLAYER " + player;
    }

    public void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
        _ball.SetActive(false);
    }

    public void HideStartScene()
    {
        _startScene.SetActive(false);
        _ball.SetActive(true);
    }
}
