using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TMP_Text pauseText;

    [SerializeField] Button resumeButton;
    [SerializeField] TMP_Text resumeText;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void SetIsLevelComplete(bool isLevelComplete)
    {
        if(isLevelComplete)
        {
            pauseText.text = "LEVEL COMPLETE!";
            resumeText.text = "Next Level";
            resumeButton.interactable = true;
        }
        else
        {
            pauseText.text = "LEVEL FAILED";
            resumeText.text = "Resume";
            resumeButton.interactable = false;
        }
    }
}
