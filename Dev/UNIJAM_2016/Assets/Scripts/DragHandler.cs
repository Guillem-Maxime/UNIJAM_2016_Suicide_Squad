﻿using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;



public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public delegate void CollisionDelegate(Object itemBeingDragged, Object itemCollided);

    public event CollisionDelegate CollisionEvent;

    public static Object itemBeingDragged;
    private Vector3 startPosition;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        itemBeingDragged = gameObject.GetComponent<Object>();
        startPosition = transform.position;
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        itemBeingDragged = null;
        transform.position = startPosition;

    }

    #endregion

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<Object>().getTag() == "interactable")
        {
            Object itemCollided = coll.gameObject.GetComponent<Object>();

            if (CollisionEvent != null)
            {
                CollisionEvent(itemBeingDragged, itemCollided);
            }
        }

    }


}
