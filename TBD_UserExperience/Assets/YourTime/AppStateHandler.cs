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
    private AppStateHandler() { }
    public static AppStateHandler Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new AppStateHandler();
                InteractionsController.OnButtonClicked += instance.Test;
                
                string openedScene = SceneManager.GetActiveScene().name.ToString();
                currentScene = openedScene;
                navigationStack.Add(currentScene);
            }
            return instance;
        }
    }

    public void ChangeScene(string openedScene)
    {
        SceneManager.LoadScene(openedScene);
        currentScene = openedScene;
        navigationStack.Add(currentScene);
    }

    public void Test()
    {
        Debug.Log("I am heeereeee");
    }

    public void SubmitStars(int StarsNumber)
    {
        Debug.Log("Grade: " + StarsNumber);
        //ChangeScene(false);
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
        //Instance.currentScene = navigationStack.Last();

        //SceneManager.LoadScene(Instance.currentScene);
        
    }
    private void Awake()
    {

        /*if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            //Instance.currentScene = "SplashScreen"; //Only gets called the first time the app starts
        }
        DontDestroyOnLoad(gameObject);
        navigationStack.Clear();
        navigationStack.Add("SplashScreen");*/
    }

}
