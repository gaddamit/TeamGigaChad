using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    private bool iSGameOver = false;
    [SerializeField] GameObject pauseMenu;
    private Timer timer;
    
    private FireSpreader fireSpreader;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        timer = GetComponent<Timer>();
        timer.OnTimerOver += OnGameOver;

        fireSpreader = FindObjectOfType<FireSpreader>();
        fireSpreader.OnFireSpreadStopped += OnGameComplete;
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

    public void OnGameComplete()
    {
        fireSpreader.OnFireSpreadStopped -= OnGameComplete;
        iSGameOver = true;
        Invoke("ShowWinScreen", 2.0f);
    }

    public void ShowWinScreen()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<PauseMenu>().SetIsLevelComplete(true);
    }
}
