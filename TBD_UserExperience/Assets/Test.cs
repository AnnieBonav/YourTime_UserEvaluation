using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        AppStateHandler.Instance.Test();
        //AppStateHandler.Instance.SetCurrentScene("Annie");
        //AppStateHandler.Instance.Test();
        
    }
}