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
    public List<GameObject> delayedFirstDayList;
    [SerializeField]
    public List<GameObject> secondDayList;
    [SerializeField]
    public List<GameObject> delayedSecondDayList;
    [SerializeField]
    public List<GameObject> thirdDayList;
    [SerializeField]
    public List<GameObject> delayedThirdDayList;

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

    public void setCurrentObjectsActive(bool isActive, int mDay)
    {
        switch (mDay)
        {
            case (0):
                foreach (GameObject gameObj in currentListObject)
                {
                    if (!isInList(gameObj, delayedFirstDayList)) gameObj.SetActive(isActive);
                }
            break;
            case (1):
                foreach (GameObject gameObj in currentListObject)
                {
                    if (!isInList(gameObj, delayedSecondDayList)) gameObj.SetActive(isActive);
                }
                break;
            case (2):
                foreach (GameObject gameObj in currentListObject)
                {
                    if (!isInList(gameObj, delayedThirdDayList)) gameObj.SetActive(isActive);
                }
                break;
                
        }
    }

    public void loadSceneObjects(int mDay) 
    {
        switch (mDay + 1)
        {
            case (1):
                LoadDayOne();
                setAllObjectsActive(false);
                setCurrentObjectsActive(true, mDay);
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
            case (2):
                LoadDayTwo();
                setAllObjectsActive(false);
                setCurrentObjectsActive(true, mDay);
                if (findObjectsEvent != null)
                {
                    findObjectsEvent();
                }
                break;
            case (3):
                LoadDayThree();
                setAllObjectsActive(false);
                setCurrentObjectsActive(true, mDay);
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
    */

    public void setSpecificActive(GameObject gameObject, bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public GameObject searchInList(string name)
    {
        GameObject result = new GameObject();

        foreach (GameObject gameObject in currentListObject)
        {
            if (gameObject.GetComponent<Object>().getName() == name)
                result = gameObject;
        }

        return result;
    }
    
    private bool isInList(GameObject gameObject, List<GameObject> list)
    {
        foreach(GameObject gObj in list)
        {
            if (gameObject == gObj) return true;
        }
        return false;
    }

}
