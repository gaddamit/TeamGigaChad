using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField]
    private int _scoreInterval = 100;
    public TMP_Text scoreText;
    public Player player;

    public TMP_Text menuScoreText;
    public TMP_Text menuScoreTextShadow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectableCollected()
    {
        _score += 10;
        scoreText.text = _score.ToString();
        menuScoreText.text = _score.ToString();
        menuScoreTextShadow.text = _score.ToString();
        if(_score % _scoreInterval == 0)
        {
            player.IncreaseSpeed();
        }
    }
}
