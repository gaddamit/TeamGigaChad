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

    [SerializeField]
    private AudioSource[] _backgroundMusic;

    void Awake()
    {
        // Setup Background Music
        _backgroundMusic = new AudioSource[2];
        _backgroundMusic[0] = GameObject.Find("Audios/BackgroundAudio").GetComponent<AudioSource>();
        _backgroundMusic[1] = GameObject.Find("Audios/CompleteAudio").GetComponent<AudioSource>();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
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
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        string name = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( index );
        Initiate.Fade(name, Color.black, 1);

        Time.timeScale = 1;
    }

    public void SetIsLevelComplete(bool isLevelComplete)
    {
        if(isLevelComplete)
        {
            pauseText.text = "LEVEL COMPLETE!";
            resumeText.text = "Next Level";
            resumeButton.interactable = true;

            PlayLevelCompleteMusic();

            resumeButton.onClick.RemoveAllListeners();
            resumeButton.onClick.AddListener(() => 
                    {
                        LoadNextLevel();
                    }
                );
        }
        else
        {
            pauseText.text = "LEVEL FAILED";
            resumeText.text = "Resume";
            resumeButton.interactable = false;
        }
    }

    // Play level complete music and stop background music
    private void PlayLevelCompleteMusic()
    {
        if(_backgroundMusic[0])
        {
            _backgroundMusic[0].Stop();
        }

        if(_backgroundMusic[1])
        {
            _backgroundMusic[1].Play();
        }
    }

    // Move to the next level, if there is no next level, go to the main menu
    private void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        string name = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( index );
        if(string.IsNullOrEmpty(name))
        {
            Initiate.Fade("MainMenu", Color.black, 1);
        }
        else
        {
            Initiate.Fade(name, Color.black, 1);
        }
    }
}
