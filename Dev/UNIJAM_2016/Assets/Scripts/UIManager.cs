using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    Text superbetexte;

    public void write(string phrase)
    {
        superbetexte.text = phrase; 
    }

	// Use this for initialization

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
