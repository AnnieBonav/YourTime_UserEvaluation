using BreathExercise;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace BreathExercise {

    [Serializable]
    public class BreathingState : MonoBehaviour //OnAwake nor awake work
    {
        public GameObject PrefabToShow;
        public StateName StateName;
        public int StateDuration;

        private GameObject prefabShown;

        public void InstancePrefab(GameObject prefabParent)
        {
            prefabShown = Instantiate(PrefabToShow);
            prefabShown.transform.SetParent(prefabParent.transform, false);

            prefabShown.SetActive(false);
        }

        public void ShowPrefab()
        {
            prefabShown.SetActive(true); //Change to visible or not visible

            if(StateName == StateName.Start)
            {
                prefabShown.GetComponent<Animation>().Play();
                Debug.Log("Tries animation");
            }
        }

        public void HidePrefab()
        {
            prefabShown.SetActive(false);
        }
    }
}

