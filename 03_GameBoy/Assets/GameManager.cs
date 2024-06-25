using UnityEngine;
using GBTemplate;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    [SerializeField] private AudioClip[] audioClips;
    
    public GameObject gameOverMenu;
    public GameObject gamePausedMenu;

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
        gamePausedMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePausedMenu.SetActive(false);
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
