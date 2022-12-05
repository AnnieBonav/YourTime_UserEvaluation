using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryTimer : MonoBehaviour
{
    //OTHER SCRIPT (the one that raises the event)
    //public delegate void OnTimerEnds(int duration);
    //public static event OnTimerEnds onTimerEnds;

    private void OnEnable()
    {
        //MyTimer.onTimerEnds += AnnounceTimer; //Add it
        //MyTimer.onTimerEnds -= AnnounceTimer; //Remove it
    }

    private void AnnounceTimer(int duration)
    {
        //use duration
        Debug.Log("I was called!");
    }
}
