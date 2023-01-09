using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreathExercise;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using System;
using static BreathExercise.BreathingStateMachine;
using static CardInteraction;

namespace BreathExercise
{
    public enum StateName { Off, Start, BreathIn, HoldIn, BreathOut, HoldOut, End };

    public class BreathingStateMachine : MonoBehaviour
    {
        public GameObject TitlesParent;
        private BreathingState currentState;

        public Animation numbersAnimation;

        [SerializeField]
        private List<BreathingState> BreathingStates = new List<BreathingState>();

        [SerializeField]
        private int maxIterations;

        private int currentIterations;
        private MyTimer exerciseTimer;
        private bool isRunning = false;

        public ParticleSystem breathingParticles;

        private void Awake() //Happens every time the scene is opened
        {
            MyTimer.onTimerEnds += CheckState;
            exerciseTimer = new MyTimer(5);
            foreach (BreathingState state in BreathingStates)
            {
                state.InstancePrefab(TitlesParent);
            }
            currentState = BreathingStates[1];
            currentState.ShowPrefab();
            //numbersAnimation.Play();
            
            isRunning = true;
        }
        private void OnDisable()
        {
            /*
            foreach(Transform child in TitlesParent.transform)
            {
                Destroy(child);
            }*/
            Debug.Log("Breathing State was disabled");
        }

        private void Start()
        {
            currentIterations = 0;
        }

        private void ChangeState(BreathingState newState)
        {
            currentState.HidePrefab();
            currentState = newState;
            exerciseTimer.ModifyTime(currentState.StateDuration); //INstead of having these weird references I could have each objects observing each other
            currentState.ShowPrefab();
        }

        void Update()
        {
            if (isRunning)
            {
                exerciseTimer.CheckStatus();
            }
        }


        private void CheckState()
        {
            switch (currentState.StateName)
            {
                case StateName.Off:
                    isRunning = true;
                    ChangeState(BreathingStates[1]); //Goes to Start
                    break;

                case StateName.Start:

                    breathingParticles.Play(true);
                    ChangeState(BreathingStates[2]); //Goes to Breath In
                    break;

                case StateName.BreathIn:
                    currentIterations++;
                    ChangeState(BreathingStates[3]); //Goes to Hold In
                    break;

                case StateName.HoldIn:
                    ChangeState(BreathingStates[4]); //Goes to Breath Out 
                    break;

                case StateName.BreathOut:
                    ChangeState(BreathingStates[5]); //Goes to Hold out
                    break;

                case StateName.HoldOut: 
                    if (currentIterations < maxIterations) //Goes to Breath in if the current iterations are lower than max iterations
                    {
                        breathingParticles.Play(true);
                        ChangeState(BreathingStates[2]);
                    }
                    else{ //Goes to end if the current iterations are higher than the max iterations
                        breathingParticles.Stop(true);
                        ChangeState(BreathingStates[6]);
                    }
                    
                    break;

                case StateName.End:
                    Debug.Log("This has ended");
                    MyTimer.onTimerEnds -= CheckState; //Unsuscribe to timer
                    isRunning = false;
                    break;

                default:
                    Debug.Log("This state does not exist");
                    MyTimer.onTimerEnds -= CheckState;
                    isRunning = false;
                    break;
            }
        }
    }
}

