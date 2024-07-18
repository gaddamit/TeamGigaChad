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
        Debug.Log("Player collected a collectable: " + _score);

        if(_score % _scoreInterval == 0)
        {
            player.IncreaseSpeed();
        }
    }
}
