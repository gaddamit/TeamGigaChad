using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    private bool isTimerOver = false;
    public delegate void TimerOver();
    public event TimerOver OnTimerOver;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    void Update()
    {
        // If timer is enabled, update remaining time
        // Timer in tutorial is disabled
        if(timerText.IsActive())
        {
            remainingTime -= Time.deltaTime;
        }

        if(remainingTime > 0)
        {
            UpdateTimer(remainingTime);
        }
        else
        {
            remainingTime = 0;
            UpdateTimer(remainingTime);
            if(!isTimerOver && OnTimerOver != null)
            {
                TimerOverEvent();
            }
        }
    }

    // Update timer text
    void UpdateTimer(float time)
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60); 
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }

    // Callback assigned time over event
    public void TimerOverEvent()
    {
        OnTimerOver?.Invoke();
    }
}
