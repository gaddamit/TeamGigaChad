using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private int _keysToCollect = 8;
    public bool AreKeysCollected => _keysToCollect <= 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollectedKey()
    {
        _keysToCollect--;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
