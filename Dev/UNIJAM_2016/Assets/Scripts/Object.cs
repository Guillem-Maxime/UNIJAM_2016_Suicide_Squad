using UnityEngine;
using System.Collections;
using System;

public class Object : MonoBehaviour{

    bool isDragged;

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

        DragNDrop();
        
        
    }

    private void DragNDrop()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        if (Physics.Raycast(ray, out hit, 50f))
        {
            isDragged = true;
        }

        if (Input.GetKey(KeyCode.Mouse0) && isDragged)
        {
            Dragging();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isDragged = false;
            this.transform.position = initialPosition;
        }
    }

    private void Dragging()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 draggingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggingPosition.z = 0;
        this.transform.position = draggingPosition;
    }


}
