using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonImplementation : MonoBehaviour
{
    public static SingletonImplementation Instance { get; private set; }
    private string currentScene = "";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Instance.currentScene = "SplashScreen"; //Only gets called the first time the app starts
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Test()
    {
        Debug.Log("I was tested");
    }

    //TO CALL FROM ANOTHER SCRIPT
    //SingletonImplementation.Instance.Test();
    //Debug.Log(SingletonImplementation.Instance.currentScene);
}
