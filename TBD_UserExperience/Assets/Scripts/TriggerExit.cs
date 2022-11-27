using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    public static TriggerExit instance;

    //[HideInInspector]
    public VRUIOperations currentCollider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        currentCollider.OnExit.Invoke();
    }
}
