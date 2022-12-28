using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    private float currentTime;
    public float timerDuration;

    public delegate void OnTimerEnds();
    public static event OnTimerEnds onTimerEnds;

    // Update is called once per frame...not here I guess
    public void Update()
    {
        Debug.Log("Update in MyTimer?");
        
    }

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

    void Start() //I create the delegate where the action wil be triggered, then I make an object subrscibe to it from anotehr script
    {
        //onTimerEnds += AnnounceTimer;
    }

    
}
