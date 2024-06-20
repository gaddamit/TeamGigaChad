using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;

    private bool _isGamePaued = false;
    
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaued)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        _isGamePaued = true;
    }
    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _isGamePaued = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowGameOverPanel()
    {
        Debug.Log("Null MU LA ? : " + _gameOverPanel != null);
        Debug.Log("Nesne : " + _gameOverPanel);
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
