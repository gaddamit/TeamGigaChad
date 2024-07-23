using System;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;
    [SerializeField]
    private int _scoreIntervals = 100;
    public TMP_Text scoreText;
    public Player player;

    public override void Awake()
    {
        base.Awake();
        
    }

    private void OnDisable()
    {
        
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        scoreText.text = $"{_score}";

        if((_score % _scoreIntervals) == 0)
        {
            player.IncreaseSpeed();
        }
    }

    public void GameOver()
    {
        //UIManager.Instance.ShowGameOverScreen();
    }   
}
