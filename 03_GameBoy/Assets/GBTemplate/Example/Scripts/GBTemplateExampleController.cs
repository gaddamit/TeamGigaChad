using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace GBTemplate
{
    public class GBTemplateExampleController : MonoBehaviour
    {
        //Input tester stuff
        public SpriteRenderer sprUp;
        public SpriteRenderer sprDown;
        public SpriteRenderer sprLeft;
        public SpriteRenderer sprRight;
        public SpriteRenderer sprSelect;
        public SpriteRenderer sprStart;
        public SpriteRenderer sprA;
        public SpriteRenderer sprB;
        public Color inputColorInactive;
        public Color inputColorActive;

        public AudioClip exampleMusic;
        public AudioClip exampleSoundA;
        public AudioClip exampleSoundB;

        private GBConsoleController gb;
        private bool whiteFade = false;

        // Start is called before the first frame update
        void Start()
        {
            //Getting the instance of the console controller, so we can access its functions
            gb = GBConsoleController.GetInstance();

            //Have some music playing!
            gb.Sound.PlayMusic(exampleMusic);
        }

        // Update is called once per frame
        void Update()
        {
            if (gb.Input.ButtonStartJustPressed && !gb.Display.Fading)
            {
                Debug.Log("Start button pressed");
                gb.Sound.PlaySound(exampleSoundA);
                StartCoroutine(FadeTest());
                whiteFade = !whiteFade;
            }
        }

        private void UpdateInputTest()
        {
            sprUp.color = gb.Input.Up ? inputColorActive : inputColorInactive;
            sprDown.color = gb.Input.Down ? inputColorActive : inputColorInactive;
            sprLeft.color = gb.Input.Left ? inputColorActive : inputColorInactive;
            sprRight.color = gb.Input.Right ? inputColorActive : inputColorInactive;
            sprSelect.color = gb.Input.ButtonSelect ? inputColorActive : inputColorInactive;
            sprStart.color = gb.Input.ButtonStart ? inputColorActive : inputColorInactive;
            sprA.color = gb.Input.ButtonA ? inputColorActive : inputColorInactive;
            sprB.color = gb.Input.ButtonB ? inputColorActive : inputColorInactive;
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
}