using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

   [SerializeField] GameObject pauseMenu;
   [SerializeField] Button resumeButton;
   [SerializeField] TMP_Text pauseMessage;
   public void Pause(bool isDead = false)
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        pauseMessage.text = isDead ? "U DIED" : "PAUSED";
        if(isDead)
            resumeButton.interactable = false;
        else
            resumeButton.interactable = true;
    }
    public void Home()
    {
        int index = 0;
        string name = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( index );
        Initiate.Fade(name, Color.black, 1);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        string name = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( index );
        Initiate.Fade(name, Color.black, 1);

        Time.timeScale = 1;
    }
}
