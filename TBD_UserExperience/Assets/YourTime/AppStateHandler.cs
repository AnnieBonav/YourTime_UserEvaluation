using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CurrentScene { SplashScreen, MainMenu, ExerciseSplash, BreathingExercise, About, AfterExercise };

public class AppStateHandler : MonoBehaviour
{
    public static AppStateHandler Instance { get; private set; }

    public List<CurrentScene> navigationStack = new List<CurrentScene>();

    public CurrentScene currentScene { get; private set; } //TODO: Implement stack for navigation

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
        navigationStack.Clear();
        navigationStack.Add(CurrentScene.SplashScreen);
    }

    private void Start()
    {
        Debug.Log("Start got called"); //Only gets called the frist time the app starts
    }

    public void SetActiveScene(CurrentScene openedScene)
    {
        navigationStack.Add(openedScene);
        Instance.currentScene = navigationStack.Last();
    }


    public void ChangeScene(bool changeToAbout) //TODO: Change so where to go is not hard coded
    {
        Debug.Log(navigationStack);
        if (changeToAbout)
        {
            SceneManager.LoadScene("About");
            Instance.SetActiveScene(CurrentScene.About);
        }
        else
        {
            switch (Instance.currentScene)
            {
                case CurrentScene.SplashScreen:
                    SceneManager.LoadScene("MainMenu");
                    Instance.SetActiveScene(CurrentScene.MainMenu);
                    break;
                case CurrentScene.MainMenu:
                    SceneManager.LoadScene("ExerciseSplash");
                    Instance.SetActiveScene(CurrentScene.ExerciseSplash);
                    break;
                case CurrentScene.ExerciseSplash:
                    SceneManager.LoadScene("BreathingExercise");
                    Instance.SetActiveScene(CurrentScene.BreathingExercise);
                    break;
                case CurrentScene.BreathingExercise:
                    SceneManager.LoadScene("AfterExercise");
                    Instance.SetActiveScene(CurrentScene.AfterExercise);
                    break;
                case CurrentScene.AfterExercise:
                    SceneManager.LoadScene("MainMenu");
                    Instance.SetActiveScene(CurrentScene.MainMenu);
                    break;
            }
        }
    }

    public void GoBack()
    {
        navigationStack.RemoveAt(navigationStack.Count - 1); //Pop the last one to change to the new current
        Instance.currentScene = navigationStack.Last();

        switch (Instance.currentScene)
        {
            case CurrentScene.SplashScreen:
                SceneManager.LoadScene("SplashScreen");
                break;
            case CurrentScene.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case CurrentScene.ExerciseSplash:
                SceneManager.LoadScene("ExerciseSplash");
                break;
            case CurrentScene.BreathingExercise:
                SceneManager.LoadScene("BrethingExercise");
                break;
            case CurrentScene.AfterExercise:
                SceneManager.LoadScene("AfterExercise");
                break;
        }
    }

}
