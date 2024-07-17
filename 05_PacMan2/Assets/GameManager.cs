using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
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
        score += 10;
        scoreText.text = score.ToString();
        Debug.Log("Player collected a collectable: " + score);

        if(score % 100 == 0)
        {
            float currentSpeed = player.GetSpeed();
            player.SetSpeed(currentSpeed + 1);
        }
    }
}
