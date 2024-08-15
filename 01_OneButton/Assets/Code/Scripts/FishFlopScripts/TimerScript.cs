using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference for texmeshproui
    private float timeRemaining = 25f; // to set seconds

    void Start()
    {
        UpdateTimerText(); 
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; 
            timeRemaining = Mathf.Max(0, timeRemaining); // Time is gonan hit 0 and gonna stop.
            UpdateTimerText(); 

            if (timeRemaining == 0)
            {
                OnTimerEnd(); 
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); // Minutes
        int seconds = Mathf.FloorToInt(timeRemaining % 60); // Seconds
        timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds); // Formatting the time.
    }

    void OnTimerEnd()
    {
        Debug.Log("Timer has ended. Exiting game.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // When time is done game stops.
#else
        Application.Quit(); // Quits the application in a built version
#endif
    }
}

