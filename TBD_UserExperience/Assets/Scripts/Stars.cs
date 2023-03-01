using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private Material hoverMaterial;

    [SerializeField]
    private Material baseMaterial;

    private void Awake()
    {
        for(int i = 0; i < objectsAmount; i++)
        {
            objects.Add(new Star(objectPrefab, i, objectOffset, parent));
        }
        Debug.Log(objects);
    }

    public void ChangeStarColor(string starId)
    {
        for(int i = int.Parse(starId) -1; i >= 0; i--)
        {
            objects[i].ChangeHoverMaterial(hoverMaterial);
        }
    }

    public void WhipeStars()
    {
        for(int i = 0; i <objectsAmount; i++)
        {
            objects[i].ChangeBaseMaterial(baseMaterial);
        }
    }
}

public class Star : MonoBehaviour
{
    public int id;
    public GameObject starInstance;
    public Star(GameObject starPrefab, int id, float objectOffset, GameObject parent)
    {
        this.id = id;

        Instance(starPrefab, id, objectOffset, parent);
    }

    public void ChangeHoverMaterial(Material hoverMaterial)
    {
        starInstance.GetComponent<MeshRenderer>().material = hoverMaterial;
    }

    public void ChangeBaseMaterial(Material baseMaterial)
    {
        starInstance.GetComponent<MeshRenderer>().material = baseMaterial;
    }

    public void Instance(GameObject starPrefab, int id, float objectOffset, GameObject parent)
    {
        starInstance = Instantiate(starPrefab);
        starInstance.name = (id+1).ToString();
        starInstance.tag = "star";
        starInstance.transform.SetParent(parent.transform, false);
        starInstance.transform.position = new Vector3(starInstance.transform.position.x + id * objectOffset * parent.transform.localScale.x, starInstance.transform.position.y, starInstance.transform.position.z);

    }
}
