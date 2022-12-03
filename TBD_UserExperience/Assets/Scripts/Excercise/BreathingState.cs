using BreathExercise;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace BreathExercise {

    public enum StateName {Start, BreathIn, HoldIn, BreathOut, HoldOut, End};

    [Serializable]
    public class BreathingState : MonoBehaviour
    {
        [SerializeField]
        public GameObject PrefabToShow;

        [SerializeField]
        public StateName stateName;

        private GameObject prefabShown;

        public BreathingState(StateName _StateName, GameObject _PrefabToShow)
        {
            PrefabToShow = _PrefabToShow;
            stateName = _StateName;
            this.InstancePrefab(); //Instantiate hidden once, then I do not need to make the call again
        }
        
        public void InstancePrefab()
        {
            prefabShown = Instantiate(PrefabToShow);
            prefabShown.SetActive(false);
        }

        public void ShowPrefab()
        {
            prefabShown.SetActive(true);
        }

        public void HidePrefab()
        {
            prefabShown.SetActive(false);
        }

        
    }
}

