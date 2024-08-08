using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    private void Start()
    {
        off = true; 
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if(off && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true; 
        }
        else if (on && Input.GetButtonDown("F"))
        {
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
    }
}
