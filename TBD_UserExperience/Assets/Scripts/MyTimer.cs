using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    [SerializeField]
    private float currentTime;

    [Header("Limit Settings")]
    public float timerLimit;

    public delegate void OnTimerEnds();
    public static event OnTimerEnds onTimerEnds;

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 0)
        {
            currentTime = currentTime -= Time.deltaTime;
        }
        else
        {
            onTimerEnds?.Invoke();
            currentTime = timerLimit;
        }
    }

    void Start() //I create the delegate where the action wil be triggered, then I make an object subrscibe to it from anotehr script
    {
        //onTimerEnds += AnnounceTimer;
    }

    
}
