using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardInteraction : MonoBehaviour
{
    public string ActivityName;

    public void StartActivity()
    {
        SceneManager.LoadScene(ActivityName);
    } 
}
