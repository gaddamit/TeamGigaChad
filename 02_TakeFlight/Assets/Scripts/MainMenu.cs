using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject quitButton;


    private void Awake()
    {
#if UNITY_WEBGL
            // adjust rect transform of play button
            playButton.transform.localPosition = new Vector3(0, -250, 0);
            quitButton.SetActive(false);
#endif
    }

    public void PlayGame()
    {
        Initiate.Fade("Scenes/Tutorial", Color.black, 1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
    }
}
