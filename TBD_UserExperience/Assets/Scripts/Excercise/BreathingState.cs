using BreathExercise;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BreathExercise {

    public enum StateName {Start, BreathIn, HoldIn, BreathOut, HoldOut, End};

    public abstract class BreathingState
    {
        protected void Start()
        {
            Debug.Log("Did I awake?");
        }
        //public StateName stateName;
        protected string thisString = "BreathExercise";
        //[SerializeField] protected Animation animation;

        public void PrintStateName()
        {
            Debug.Log(thisString);
        }
    }
}

