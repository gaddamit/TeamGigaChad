using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBTemplate;

public class GameManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] audioClips;

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
        
    }
}
