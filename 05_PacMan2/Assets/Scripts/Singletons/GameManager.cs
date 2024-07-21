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
        //Collectable.OnCollectableCollected += CollectableCollected;
    }

    private void OnDisable()
    {
        //Collectable.OnCollectableCollected -= CollectableCollected;
    }

    public void CollectableCollected(int score)
    {
        /*_score += score;
        scoreText.text = $"{_score}";

        if(score % _scoreIntervals == 0)
        {
            player.IncreaseSpeed();
        }*/
    }
}
