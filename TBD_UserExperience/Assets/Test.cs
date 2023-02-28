using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        InteractionsController.GoBackButtonClicked += Testing;
    }

    private void Testing()
    {
        Debug.Log("Inside Test");
    }

    void Start()
    {
        //AppStateHandler.Instance.Test();        
    }
}
