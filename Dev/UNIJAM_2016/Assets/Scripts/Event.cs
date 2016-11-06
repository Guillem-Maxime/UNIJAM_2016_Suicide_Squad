using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Event : MonoBehaviour {

    private float time;

    public float Time
    {
        get;
        set;
    }

    //private bool aEteLance = false; 

    public bool AEteLance
    {
        get;
        set;
    }

    public UnityAction action;
    public int dangerModif = 0;
    public int fatigueModif = 0;

    public void launch()
    {
        action();
    }

	void Start () {

    }
	
	void Update () {
	
	}
}
