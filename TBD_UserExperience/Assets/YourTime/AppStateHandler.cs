using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class AppStateHandler
{
    static public string currentScene { get; private set; }
    static private AppStateHandler instance;
    public static List<string> navigationStack = new List<string>();

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeLoad()
    {
        if (instance == null)
        {
            instance = new AppStateHandler();
            InteractionsController.GoForwardButtonClicked += instance.GoForward;
            InteractionsController.GoBackButtonClicked += instance.GoBack;
            InteractionsController.AboutButtonClicked += instance.OpenAbout;
            InteractionsController.StarClicked += instance.SubmitStars;

            string openedScene = SceneManager.GetActiveScene().name.ToString();
            currentScene = openedScene;
            navigationStack.Add(currentScene);
        }
    }

    //Takes string (new scene) from object that raised the event
    private void SetActiveScene(string requestedScene)
    {
        SceneManager.LoadScene(requestedScene);
        currentScene = requestedScene;
        navigationStack.Add(currentScene);
    }

    private void OpenAbout()
    {
        SetActiveScene("About");
    }


    private void GoForward()
    {
        switch (currentScene)
        {
            case "SplashScreen":
                SetActiveScene("MainMenu");
                break;
            case "MainMenu":
                SetActiveScene("ExerciseSplash");
                break;
            case "ExerciseSplash":
                SetActiveScene("BreathingExercise");
                break;
            case "BreathingExercise":
                SetActiveScene("AfterExercise");
                break;
            case "AfterExercise":
                CloseExercise();
                SetActiveScene("MainMenu");
                break;
        }
    }

    public void SubmitStars(int StarsNumber)
    {
        Debug.Log("Grade: " + StarsNumber);
        GoForward();
    }

    public void GoBack()
    {
        if (currentScene == "AfterExercise")
        {
            CloseExercise();
        }
        else
        {
            navigationStack.RemoveAt(navigationStack.Count - 1); //Pop the last one to change to the new current
        }
        currentScene = navigationStack.Last();
        SceneManager.LoadScene(currentScene);
    }

    public void CloseExercise()
    {
        Debug.Log(navigationStack);
        for(int i = navigationStack.Count - 1; i > navigationStack.IndexOf("MainMenu"); i--)
        {
            Debug.Log("Remove: " + i + " " + navigationStack[i]);
            navigationStack.RemoveAt(navigationStack.Count - 1);
            
        }
    }
}
