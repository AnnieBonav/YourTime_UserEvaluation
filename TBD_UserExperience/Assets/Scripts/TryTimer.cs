using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryTimer : MonoBehaviour
{
    private void OnEnable()
    {
        MyTimer.onTimerEnds += AnnounceTimer;
    }

    private void AnnounceTimer()
    {
        Debug.Log("I was called!");
    }
}
