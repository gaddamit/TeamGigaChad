using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>
{
    private int score = 0;
    public TMP_Text scoreText;
    public Player player;

    public override void Awake()
    {
        base.Awake();
        Collectable.OnPelletCollected += CollectableCollected;
    }

    private void OnDisable()
    {
        Collectable.OnPelletCollected -= CollectableCollected;
    }

    public void CollectableCollected()
    {
        score += 10;
        scoreText.text = $"{score}";
        //Debug.Log($"Player collected a collectable: {score}");

        if(score % 100 == 0)
        {
            float currentSpeed = player.GetSpeed();
            player.SetSpeed(currentSpeed *= 1.15f);
        }
    }
}
