using UnityEngine;
using System.Collections;
using System;

public class ButtonPress : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        //startPosition = GetComponent<Transform>().position;
        startPosition = transform.localPosition;
    }

    public void MoveButton()
    {
        Debug.Log("I was pressed");
    }

    void Update()
    {
        
    }

}