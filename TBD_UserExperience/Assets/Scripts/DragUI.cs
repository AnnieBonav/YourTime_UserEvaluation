using UnityEngine;

public class DragUI : MonoBehaviour
{
    public Transform pointer;

    [Header("Select To INclude In Drag")]
    public bool x;
    public bool y;
    public bool z;

    public void Drag()
    {
        float newx = x ? pointer.position.x : transform.position.x; //If x is enabled then the pointers position will be equal to this x
        float newy = y ? pointer.position.y : transform.position.y;
        float newz = z ? pointer.position.z : transform.position.z;

        transform.position = new Vector3(newx, newy, newz);
    }
}
