using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    private List<Star> objects = new List<Star>();

    [Header("Objects Bulking Settings")]
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private float objectOffset;

    [SerializeField]
    private int objectsAmount = 5;

    [SerializeField]
    private GameObject parent;

    private void Awake()
    {
        for(int i = 0; i < objectsAmount; i++)
        {
            objects.Add(new Star(objectPrefab, i, objectOffset, parent));
            objects[i].PrintStarStatus();
        }
    }
}

public class Star : MonoBehaviour
{
    public int id;
    public GameObject starInstance;
    public bool hovered;
    public bool isPainetd;
    public Star(GameObject starPrefab, int id, float objectOffset, GameObject parent)
    {
        this.id = id;
        hovered = false;
        isPainetd = false;

        Instance(starPrefab, id, objectOffset, parent);
    }

    public void Instance(GameObject starPrefab, int id, float objectOffset, GameObject parent)
    {
        starInstance = Instantiate(starPrefab);
        starInstance.transform.SetParent(parent.transform, false);
        starInstance.transform.position = new Vector3(starInstance.transform.position.x + id * objectOffset * parent.transform.localScale.x, starInstance.transform.position.y, starInstance.transform.position.z);

    }

    public void PrintStarStatus()
    {
        Debug.Log("Star id: " + id.ToString());
        Debug.Log("Status: " + hovered);
        Debug.Log("Status: " + isPainetd);
    }
}
