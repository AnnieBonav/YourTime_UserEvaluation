using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    public delegate void OnTimerEnds();
    public static event OnTimerEnds onTimerEnds;

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if (hasLimit && ((countDown && currentTime <= timerLimit || !countDown && currentTime >= timerLimit)))
        {

            currentTime = timerLimit;
            onTimerEnds?.Invoke();
        }
    }

    

    void Start() //I create the delegate where the action wil be triggered, then I make an object subrscibe to it from anotehr script
    {
        //onTimerEnds += AnnounceTimer;
    }

    
}
