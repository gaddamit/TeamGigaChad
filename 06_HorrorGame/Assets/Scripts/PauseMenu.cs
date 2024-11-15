using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

// Handle the pause menu functionality
public class PauseMenu : MonoBehaviour
{
    private Vector3 _initialPosition;
    [SerializeField] GameObject pauseMenu; 


    private void Awake()
    {
        _initialPosition = pauseMenu.GetComponent<RectTransform>().localPosition;
    }
    private void Start()
    {
        
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(pauseMenu)
        {
            pauseMenu?.SetActive(true);
        }
        //ShowPauseMenu();
        Time.timeScale = 0; 
    }

    public void Home()
    {
        //HidePauseMenu();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        HidePauseMenu();

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        HidePauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    private void ShowPauseMenu()
    {
        pauseMenu.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    private void HidePauseMenu()
    {
        pauseMenu.GetComponent<RectTransform>().localPosition = _initialPosition;
    }
}
