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
        AppStateHandler.Instance.ChangeScene(true);
    }

    public void OpenNextScene() //Parameters in functions are not seen in the inspector inside Event Trigger
    {
        if(SceneName == "")
        {
            AppStateHandler.Instance.ChangeScene(false);
        }
        else
        {
            SceneManager.LoadScene(SceneName); //In case I want to go somewhere not linear TODO: Change
        }
        
    }

    public void GoBack()
    {
        AppStateHandler.Instance.GoBack();
    }

    public void GetStarted()
    {
        startExerciseClick?.Invoke();
    }
}
