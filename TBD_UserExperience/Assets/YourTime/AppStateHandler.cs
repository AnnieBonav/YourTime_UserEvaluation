using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentScene { SplashScreen, MainMenu, BreathingExercise, About };

public class AppStateHandler : MonoBehaviour
{
    public static AppStateHandler Instance { get; private set; }
    public CurrentScene currentScene { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Instance.currentScene = CurrentScene.SplashScreen; //Only gets called the first time the app starts
        }
        DontDestroyOnLoad(gameObject);
        Instance.ChangeScene(CurrentScene.SplashScreen); //Gets called every time the scene opens
    }

    private void Start()
    {
        Debug.Log("Start got called"); //Only gets called the frist time the app starts
    }

    public void ChangeScene(CurrentScene newScene)
    {
        Instance.currentScene = newScene;
    }

}
