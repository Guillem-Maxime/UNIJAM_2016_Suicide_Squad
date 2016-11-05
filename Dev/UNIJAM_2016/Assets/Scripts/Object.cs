using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Object : MonoBehaviour{

    [SerializeField]
    private string nameObject;
    public string getName() { return nameObject; }
    [SerializeField]
    private string tagObject;
    public string getTag() { return tagObject; }

    [SerializeField]
    public List<Sprite> spriteList;

    private bool isDragged;
    //private bool isAttached;
    //public bool getIsAttached() { return isAttached; }
    //public void setIsAttached(bool) {  }

	// Use this for initialization
	void Start () {
        if(spriteList.Count == 0)
        {
            spriteList.Add(this.GetComponent<Renderer>().GetComponent<Sprite>());
        }
        else
        {
            spriteList[0] = this.GetComponent<Renderer>().GetComponent<Sprite>();
        }

	}
	
	// Update is called once per frame
	void Update () {
        
        
    }


}
