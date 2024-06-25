using UnityEngine;
using GBTemplate;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGamePaused = false;
    public bool IsGamePaused
    {
        get => _isGamePaused;
        set => _isGamePaused = value;
    }
    private bool _isGameOver = false;
    public bool IsGameOver
    {
        get => _isGameOver;
        set => _isGameOver = value;
    }

    [SerializeField] private AudioClip[] audioClips;
    
    public GameObject gameOverMenu;
    public GameObject gamePausedMenu;
    public GameObject gameCompleteMenu;

    private GBConsoleController gb;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the instance of the console controller, so we can access its functions
        gb = GBConsoleController.GetInstance();

        //Have some music playing!
        gb.Sound.PlayMusic(audioClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(gb.Input.ButtonStartJustPressed)
        {
            if(!_isGameOver)
            {
                ShowGamePaused();
            }
        }
    }

    public void ShowGameOver()
    {
        if(!_isGameOver)
        {
            Time.timeScale = 0;
            _isGameOver = true;
            gameOverMenu.SetActive(true);
        }
    }

    public void ShowGamePaused()
    {
        if(_isGameOver || _isGamePaused)
        {
            return;
        }
        
        _isGamePaused = true;
        Time.timeScale = 0;
        gamePausedMenu.SetActive(true);
    }

    public void ShowLevelComplete()
    {
        if(_isGameOver || _isGamePaused)
        {
            return;
        }

        _isGameOver = true;
        Time.timeScale = 0;
        gameCompleteMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gamePausedMenu.SetActive(false);
        Invoke("DelayUnpause", 0.1f);
    }

    private void DelayUnpause()
    {
        _isGamePaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
