using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreathExercise;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

public class BreathingStateMachine : MonoBehaviour
{
    private StartState currentState = new StartState();
    //private BreathingState anotherState = new BreathingState(); //Cannot because abstract

    private void Start()
    {
        currentState = new StartState();
        currentState.PrintStateName();

    }
}
