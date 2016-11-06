using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

enum objectTypes { };

public class ObjectManager : MonoBehaviour {

    List<GameObject> listObject;

    public delegate void FindObjectsDelegate();
    public event FindObjectsDelegate findObjectsEvent;

    [SerializeField]
    private List<GameObject> firstDayList;
    private List<GameObject> secondDayList;
    private List<GameObject> thirdDayList;

    // Use this for initialization
    void Start () {
	
	}
	

    public void setActive(bool isActive)
    {
            foreach(GameObject gameObj in listObject)
            {
                gameObj.SetActive(isActive);
            }
    }

    public void loadSceneObjects(int numberDay) 
    {
        switch (numberDay)
        {
            case (1):
                LoadDayOne();
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
            case (2):
                LoadDayTwo();
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
            case (3):
                LoadDayThree();
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
        }
    }

    public void unloadSceneObjects()
    {
        listObject.Clear();
    }


    private void LoadDayOne()
    {
        foreach(GameObject gameObj in firstDayList)
        {
            GameObject obj = (GameObject)Instantiate(gameObj);
            listObject.Add(obj);
        }
    }

    private void LoadDayTwo()
    {
        foreach (GameObject gameObj in secondDayList)
        {
            GameObject obj = (GameObject)Instantiate(gameObj);
            listObject.Add(obj);
        }
    }

    private void LoadDayThree()
    {
        foreach (GameObject gameObj in thirdDayList)
        {
            GameObject obj = (GameObject)Instantiate(gameObj);
            listObject.Add(obj);
        }
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
