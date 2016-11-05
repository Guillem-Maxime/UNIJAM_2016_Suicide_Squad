using UnityEngine;
using System.Collections;
using System;

public class Object : MonoBehaviour{

    [SerializeField]
    private string name;
    public string getName() { return name; }

    private bool isDragged;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 initialPosition;

    public Vector3 getInitialPosition()
    {
        return initialPosition;
    }

    public LayerMask interactions;

	// Use this for initialization
	void Start () {
        initialPosition = new Vector3(0, 0, 0);
        this.transform.position = initialPosition;
        isDragged = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }

    private void Dragging()
    {
        
    }


}
