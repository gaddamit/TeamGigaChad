using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private bool iSGameOver = false;
    [SerializeField] GameObject pauseMenu;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        timer = GetComponent<Timer>();
        timer.OnTimerOver += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver()
    {
        timer.OnTimerOver -= OnGameOver;
        iSGameOver = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<PauseMenu>().SetIsLevelComplete(false);
    }
}
