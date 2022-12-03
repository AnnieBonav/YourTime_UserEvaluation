using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreathExercise;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using System;

[Serializable]
public class KeyValuePair
{
    public StateName stateName;
    public GameObject statePrefab;
}

public class BreathingStateMachine : MonoBehaviour
{
    [SerializeField]
    private List<KeyValuePair> BreathingStatesInfo = new List<KeyValuePair>();

    private BreathingState currentState;

    [SerializeField]
    private List<BreathingState> BreathingStates = new List<BreathingState>();

    [SerializeField]
    private int maxIterations;

    private int currentIterations;
    private void Awake()
    {
        MyTimer.onTimerEnds += CheckState;

        foreach (KeyValuePair state in BreathingStatesInfo)
        {
            Debug.Log("Entered creation");
            BreathingStates.Add(new BreathingState(state.stateName, state.statePrefab));
        }
        currentState = BreathingStates[0]; // Define start Breathing State
        currentState.ShowPrefab();
    }

    private void Start()
    {
        currentIterations = 0;
    }

    private void ChangeState(BreathingState newState)
    {
        currentState.HidePrefab();
        currentState = newState;
        currentState.ShowPrefab();
    }


    private void CheckState()
    {
        Debug.Log("Enters Check State");
        switch (currentState.stateName)
        {
            case StateName.Start:
                ChangeState(BreathingStates[1]); //Goes to Breath In
                break;

            case StateName.BreathIn:
                ChangeState(BreathingStates[2]); //Goes to Hold In
                break;

            case StateName.HoldIn:
                ChangeState(BreathingStates[3]); //Goes to Breath Out 
                break;

            case StateName.BreathOut:
                ChangeState(BreathingStates[4]); //Goes to Hold out
                break;

            case StateName.HoldOut: //Goes to Breath in if the current iterations are lower than max iterations
                if (currentIterations < maxIterations)
                {
                    ChangeState(BreathingStates[1]);
                    currentIterations++;
                }
                else{ //Goes to end if the current iterations are higher than the max iterations
                    ChangeState(BreathingStates[5]);
                    
                }
                break;

            case StateName.End:
                Debug.Log("This has ended");
                MyTimer.onTimerEnds -= CheckState; //Unsuscribe to timer
                break;

            default:
                Debug.Log("This state does not exist");
                MyTimer.onTimerEnds -= CheckState;
                break;
        }
    }
}
