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
    public List<GameObject> firstDayList;
    [SerializeField]
    public List<GameObject> secondDayList;
    [SerializeField]
    public List<GameObject> thirdDayList;

    // Use this for initialization
    void Start () {
        listObject = new List<GameObject>();
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
        switch (numberDay + 1)
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
        foreach (GameObject gameObj in listObject)
            Destroy(gameObj);
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

    public void addObject(GameObject obj)
    {
        listObject.Add(obj);
    }

    public void removeObject(GameObject obj)
    {
        listObject.Remove(obj);
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


}
