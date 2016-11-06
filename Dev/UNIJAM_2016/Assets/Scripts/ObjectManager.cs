using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

enum objectTypes { };

public class ObjectManager : MonoBehaviour {

    List<GameObject> currentListObject;

    public delegate void FindObjectsDelegate();
    public event FindObjectsDelegate findObjectsEvent;

    [SerializeField]
    public List<GameObject> firstDayList;
    [SerializeField]
    public List<GameObject> secondDayList;
    [SerializeField]
    public List<GameObject> thirdDayList;

    // Use this for initialization
    void Start () {
        currentListObject = new List<GameObject>();
	}

    public void setAllObjectsActive(bool isActive)
    {
        foreach (GameObject gameObj in currentListObject)
        {
            gameObj.SetActive(isActive);
        }
        foreach (GameObject gameObj in firstDayList)
        {
            gameObj.SetActive(isActive);
        }
        foreach (GameObject gameObj in secondDayList)
        {
            gameObj.SetActive(isActive);
        }
        foreach (GameObject gameObj in thirdDayList)
        {
            gameObj.SetActive(isActive);
        }
    }

    public void setCurrentObjectsActive(bool isActive)
    {
            foreach(GameObject gameObj in currentListObject)
            {
                gameObj.SetActive(isActive);
            }
    }

    public void loadSceneObjects(int numberDay) 
    {
        switch (numberDay + 1)
        {
            case (1):
                LoadDayOne();
                setAllObjectsActive(false);
                setCurrentObjectsActive(true);
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
            case (2):
                LoadDayTwo();
                setAllObjectsActive(false);
                setCurrentObjectsActive(true);
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
            case (3):
                LoadDayThree();
                setAllObjectsActive(false);
                setCurrentObjectsActive(true);
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
        }
    }

    public void unloadSceneObjects()
    {
        foreach (GameObject gameObj in currentListObject)
            gameObj.SetActive(false);
        currentListObject.Clear();
    }


    private void LoadDayOne()
    {
        foreach(GameObject gameObj in firstDayList)
        {
            currentListObject.Add(gameObj);
        }
    }

    private void LoadDayTwo()
    {
        foreach (GameObject gameObj in secondDayList)
        {
            currentListObject.Add(gameObj);
        }
    }

    private void LoadDayThree()
    {
        foreach (GameObject gameObj in thirdDayList)
        {
            currentListObject.Add(gameObj);
        }
    }
    /*
    public void addObject(GameObject obj)
    {
        currentListObject.Add(obj);
    }

    public void removeObject(GameObject obj)
    {
        curentListObject.Remove(obj);
    }

    public void removeObject(int i)
    {
        listObject.RemoveAt(i);
    }

    private GameObject searchInList(GameObject gObject)
    {
        GameObject result = new GameObject();

        for (int i = 0; i < listObject.Count; i++)
        {
            if (listObject[i].gameObject == gObject)
                result = listObject[i];
        }

        return result;
    }
    */

}
