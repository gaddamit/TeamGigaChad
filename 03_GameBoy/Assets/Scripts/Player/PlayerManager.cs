using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public bool IsGameOver { get; set; }

    private GameUiHandler _gameUiHandler;



    private void Awake()
    {
        IsGameOver = false;

        _gameUiHandler = FindObjectOfType<GameUiHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnPlayerDie()
    {
        _gameUiHandler.ShowGameOverPanel();
        IsGameOver = true;
        gameObject.SetActive(false);
    }
}
