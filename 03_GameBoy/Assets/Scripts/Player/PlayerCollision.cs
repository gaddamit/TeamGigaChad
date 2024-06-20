using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerLives _playerLives;
    private PlayerManager _playerManager;
    private void Awake()
    {
        _playerLives = FindObjectOfType<PlayerLives>();

        _playerManager = FindObjectOfType<PlayerManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            _playerLives.Lives--;
            if(_playerLives.Lives <= 0)
            {
                _playerManager.OnPlayerDie();
            }
        }
    }
 }
