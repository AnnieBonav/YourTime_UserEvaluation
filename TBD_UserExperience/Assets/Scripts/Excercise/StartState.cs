using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreathExercise;
using Unity.VisualScripting;

namespace BreathExercise
{
    public class StartState : BreathingState
    {
        public StartState()
        {
            //this.thisString = "I am StartState";
        }
        //private StateName stateName = StateName.Start;
    }

    public class EndState : BreathingState
    {
        
        private void Access()
        {
            this.thisString = "Annie";
        }
    }
}



//thatString = "Bullshit";
        //this.thatString = "Bullshit 2";
        
        /*
        thisString = "Not whatever";
        private string myName = "Annie";

        //private StateName stateName = StateName.End;
        protected override string MyName
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }*/