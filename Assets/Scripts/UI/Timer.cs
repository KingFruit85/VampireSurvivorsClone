using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public bool TimerIsRunning = false;

    void Start()
    {
        TimerIsRunning = true;
    }

    void Update()
    {
        if (TimerIsRunning)
        {
            DisplayTime(Time.timeSinceLevelLoad);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
