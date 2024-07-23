using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;
    [SerializeField]
    private int _scoreIntervals = 100;
    public TMP_Text _scoreText;
    public Player player;

    public UnityEvent onGameOver;
    public override void Awake()
    {
        base.Awake();
        
    }

    private void OnDisable()
    {
        
    }

    public void IncreaseScore(int score)
    {
        if(_scoreText == null)
        {
            _scoreText = GameObject.Find("ScoreValue").GetComponent<TMP_Text>();
        }

        _score += score;
        _scoreText.text = $"{_score}";

        if((_score % _scoreIntervals) == 0)
        {
            if(player == null)
            {
                player = GameObject.Find("PacMan").GetComponent<Player>();
            }

            player.IncreaseSpeed();
        }
    }

    public void GameOver()
    {
        onGameOver.Invoke();
    }   
}
