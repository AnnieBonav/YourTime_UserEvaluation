using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class MyTimer
{
    public MyTimer(int initialDuration)
    {
        timerDuration = initialDuration;
        currentTime = timerDuration;
    }

    private float currentTime;
    public float timerDuration;

    public delegate void OnTimerEnds();
    public static event OnTimerEnds onTimerEnds;

    public void CheckStatus()
    {
        if (currentTime >= 0)
        {
            currentTime = currentTime -= Time.deltaTime;
        }
        else
        {
            onTimerEnds?.Invoke(); //Invoke changes time duration
            currentTime = timerDuration;
        }
    }

    public void ModifyTime(float newDuration)
    {
        timerDuration = newDuration;
        currentTime = timerDuration;
    }    
}
