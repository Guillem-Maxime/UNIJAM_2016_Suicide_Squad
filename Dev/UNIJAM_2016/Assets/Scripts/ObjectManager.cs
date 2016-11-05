using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum objectTypes { };

public class ObjectManager : MonoBehaviour {

    List<Object> listObject;

    private bool isDraggingObject;
    private Ray ray;
    private RaycastHit hit;

    public LayerMask interactions;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void addObject(Object obj)
    {
        listObject.Add(obj);
    }

    public void removeObject(Object obj)
    {
        listObject.Remove(obj);
    }

    public void removeObject(int i)
    {
        listObject.RemoveAt(i);
    }

    private Object searchInList(GameObject gObject)
    {
        Object result = new Object();

        for (int i = 0; i < listObject.Count; i++)
        {
            if (listObject[i].gameObject == gObject)
                result = listObject[i];
        }

        return result;
    }

}
