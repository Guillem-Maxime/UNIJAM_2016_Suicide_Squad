using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;


public class Object : MonoBehaviour{

    [SerializeField]
    private string nameObject;
    public string getName() { return nameObject; }
    //[SerializeField]
<<<<<<< HEAD
    //private bool isInterractive;
    //public bool getInterraction() { return isInterractive; }
=======
    //private string tagObject;
    //public string getTag() { return tagObject; }
>>>>>>> 447499da4381c5027331a4b9e42f285bbc8cb580

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
