using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardInteraction : MonoBehaviour
{
    public string SceneName;
    public delegate void StartExerciseClick();
    public static event StartExerciseClick startExerciseClick;

    public void OpenAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void OpenNextScene()
    {
        if(SceneName == "")
        {
            switch (AppStateHandler.Instance.currentScene)
            {
                case CurrentScene.SplashScreen:
                    SceneManager.LoadScene("MainMenu");
                    break;
                case CurrentScene.MainMenu:
                    SceneManager.LoadScene("ExerciseSplash");
                    break;
                case CurrentScene.ExerciseSplash:
                    SceneManager.LoadScene("BreathingExercise");
                    break;
            }
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
        
    }

    public void GoBack()
    {
        Debug.Log("About: " + AppStateHandler.Instance.currentScene);
        switch (AppStateHandler.Instance.currentScene)
        {
            case CurrentScene.MainMenu:
                SceneManager.LoadScene("SplashScreen");
                break;
            case CurrentScene.About:
                Debug.Log("About here");
                SceneManager.LoadScene("MainMenu");
                break;
            case CurrentScene.ExerciseSplash:
                SceneManager.LoadScene("MainMenu");
                break;
            case CurrentScene.BreathingExercise:
                SceneManager.LoadScene("ExerciseSplash");
                break;
        }
    }

    public void GetStarted()
    {
        startExerciseClick?.Invoke();
    }
}
