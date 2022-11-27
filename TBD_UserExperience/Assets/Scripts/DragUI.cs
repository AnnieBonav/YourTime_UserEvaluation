using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragUI : MonoBehaviour
{
    public Transform pointer;

    [Header("Select To INclude In Drag")]
    public bool x;
    public bool y;
    public bool z;

    private Vector3 initialPosition;
    private Vector3 currentPosition;
    public float moveAmount;

    private bool isRunning = true;

    void Start()
    {
        initialPosition = transform.position;
        currentPosition = initialPosition;

        //StartCoroutine(moving());

    }

    public void Drag()
    {
        float newx = x ? pointer.position.x : transform.position.x; //If x is enabled then the pointers position will be equal to this x
        float newy = y ? pointer.position.y : transform.position.y;
        float newz = z ? pointer.position.z : transform.position.z;

        transform.position = new Vector3(newx, newy, newz);
    }

    public void Push()
    {
        //float newZ = initialPosition.z + 0.03f;
        //transform.position.z = newZ;

        //transform.position = new Vector3(initialPosition.x, initialPosition.y, newZ);

        StartCoroutine(moving());
    }

    
    public IEnumerator moving()
    {
        Debug.Log("I am running");

        /*
        if (isRunning!)
        {
            yield break;
        }*/

        while (true)
        {
            Debug.Log("I am on a loop");
            if (currentPosition.z <= initialPosition.z + moveAmount)
            {
                currentPosition.z += 0.001f;
                transform.position = new Vector3(initialPosition.x, initialPosition.y, currentPosition.z);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                break;
            }
        }

        isRunning = false;
        /*
        while (true){
            Debug.Log("playing1");
            Debug.Log(System.DateTime.Now);
            yield return new WaitForSeconds(5f);
            Debug.Log("playing2");
        }*/
        
    }
}
