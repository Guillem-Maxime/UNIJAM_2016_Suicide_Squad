using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;


public class Object : MonoBehaviour{

    [SerializeField]
    private string nameObject;
    public string getName() { return nameObject; }

    [SerializeField]
    public List<Sprite> spriteList;

    private bool isDragged;

	// Use this for initialization
	void Start () {
        if(spriteList.Count == 0)
        {
            spriteList.Add(this.gameObject.GetComponent<Image>().sprite);
        }
        else
        {
            spriteList[0] = this.gameObject.GetComponent<Image>().sprite;
        }

	}
	
	// Update is called once per frame
	void Update () {
        
        
    }


}
