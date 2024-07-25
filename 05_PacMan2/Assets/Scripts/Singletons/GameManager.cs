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
    private PauseMenu _diedMenu;
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        InitializeScoreText();
    }

    private void OnDisable()
    {
        
    }

    private void InitializeScoreText()
    {
        if(_scoreText == null)
        {
            _scoreText = GameObject.Find("ScoreValue").GetComponent<TMP_Text>();
        }
    }

    public void IncreaseScore(int score)
    {
        InitializeScoreText();

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

    public void ResetScore()
    {
        InitializeScoreText();

        _score = 0;
        _scoreText.text = $"{_score}";
    }

    public void GameOver()
    {
        _diedMenu = GameObject.Find("PlayerDied").GetComponent<PauseMenu>();
        _diedMenu.Pause();

        TMP_Text score = GameObject.Find("PlayerDied/Score").GetComponent<TMP_Text>();
        score.text = _score.ToString();
    }   
}
