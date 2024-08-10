using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputActions : MonoBehaviour
{
    private InputActions playerInput;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new InputActions();
            playerInput.menu.pause.performed += i => pauseMenu.Pause();
        }

        playerInput.Enable();
    }
}
