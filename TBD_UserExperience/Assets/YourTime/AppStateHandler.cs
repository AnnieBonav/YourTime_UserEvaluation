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
    private AppStateHandler() {

    }

    public static AppStateHandler Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("This should not happen. Also, learn to do Throw errors. If this happens, just take the code on OnRuntimeLoad and put it if istance == null");
            }
            return instance;
        }
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeLoad()
    {
        if (instance == null)
        {
            instance = new AppStateHandler();
            InteractionsController.ChangeSceneButtonClicked += instance.ChangeScene;
            InteractionsController.GoBackButtonClicked += instance.GoBack;

            string openedScene = SceneManager.GetActiveScene().name.ToString();
            currentScene = openedScene;
            navigationStack.Add(currentScene);
        }
    }

    //Takes string (new scene) from object that raised the event
    public void ChangeScene(string requestedScene)
    {
        Debug.Log("Changing scene");
        SceneManager.LoadScene(requestedScene);
        currentScene = requestedScene;
        navigationStack.Add(currentScene);
    }

    public void SubmitStars(int StarsNumber)
    {
        Debug.Log("Grade: " + StarsNumber);
        //ChangeScene(false);
    }

    public void GoBack()
    {
        Debug.Log("Going back");
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
