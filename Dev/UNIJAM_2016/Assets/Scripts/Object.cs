using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Object : MonoBehaviour{

    [SerializeField]
    private string nameObject;
    public string getName() { return nameObject; }
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

	}
	
	// Update is called once per frame
	void Update () {
        
        
    }


}
