using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardInteraction : MonoBehaviour
{
    public string ActivityName;
    public delegate void StartExerciseClick();
    public static event StartExerciseClick startExerciseClick;
    public void StartActivity()
    {
        SceneManager.LoadScene(ActivityName);
    }

    public void ClickStartExercise()
    {
        startExerciseClick?.Invoke();
        Debug.Log("Do I exist");
    }

    public void Start()
    {
    }
}
