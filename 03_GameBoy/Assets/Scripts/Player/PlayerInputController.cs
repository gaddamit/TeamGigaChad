using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using GBTemplate;

public class PlayerInputController : MonoBehaviour
{
    public AudioClip[] audioClips;

    private GBConsoleController gb;
    private bool whiteFade = false;
    private PlayerController playerController;
    // Start is called before the first frame update
    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        //Getting the instance of the console controller, so we can access its functions
        gb = GBConsoleController.GetInstance();

        //Have some music playing!
        //gb.Sound.PlayMusic(audioClips[0]);
    }

    // Update is called once per frame
    private void Update()
    {
        if(gb.Input.LeftJustPressed)
        {
            playerController.MoveLeft();
        }
        if(gb.Input.RightJustPressed)
        {
            playerController.MoveRight();
        }
        if(gb.Input.UpJustPressed)
        {
            playerController.MoveUp();
        }
        if(gb.Input.DownJustPressed)
        {
            playerController.MoveDown();
        }
        if(gb.Input.ButtonAJustPressed)
        {
            playerController.APressed();
        }
        if(gb.Input.ButtonBJustPressed)
        {
            playerController.BPressed();
        }
    }

    public IEnumerator FadeTest()
    {
        if (whiteFade)
        {
            yield return gb.Display.StartCoroutine(gb.Display.FadeToWhite(2));
            //Insert you action / scene transition here
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            yield return gb.Display.StartCoroutine(gb.Display.FadeFromWhite(2));                
        }
        else
        {
            yield return gb.Display.StartCoroutine(gb.Display.FadeToBlack(2));
            //Insert you action / scene transition here
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            yield return gb.Display.StartCoroutine(gb.Display.FadeFromBlack(2));
        }
    }
}