using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

using DG.Tweening;
using TMPro;
using GBTemplate;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float playButtonOffset = 0;
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private AudioClip[] audioClips;

    private GBConsoleController gb;
    private bool whiteFade = false;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

#if UNITY_WEBGL
        if(playButton != null)
        {
            playButton.gameObject.transform.localPosition = new Vector3(0, playButtonOffset, 0);
        }
        if(quitButton != null)
        {
            quitButton.gameObject.SetActive(false);
        }
#endif

        TMP_Text playButtonText = playButton.GetComponentInChildren<TMP_Text>();
        playButtonText.DOFade(0.0f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    void Start()
    {
        //Getting the instance of the console controller, so we can access its functions
        gb = GBConsoleController.GetInstance();

        //Have some music playing!
        gb.Sound.PlayMusic(audioClips[0]);
    }

    void Update()
    {
        if (gb.Input.ButtonStartJustPressed && !gb.Display.Fading)
        {
            StartCoroutine(Fade());
            whiteFade = !whiteFade;
        }
    }

    public void PlayGame()
    {
        gb.Sound.PlaySound(audioClips[1]);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator Fade()
    {
        if (whiteFade)
        {
            yield return gb.Display.StartCoroutine(gb.Display.FadeToWhite(2));
            //Insert you action / scene transition here
            yield return gb.Display.StartCoroutine(gb.Display.FadeFromWhite(2));                
        }
        else
        {
            yield return gb.Display.StartCoroutine(gb.Display.FadeToBlack(2));
            //Insert you action / scene transition here
            PlayGame();
            yield return gb.Display.StartCoroutine(gb.Display.FadeFromBlack(2));
        }
    }
}
