using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public delegate void DropDelegate(Object itemBeingDragged, Object itemCollided);

    public event DropDelegate dropEvent;

    public void OnDrop(PointerEventData eventData)
    {

            if (dropEvent != null)
            {
                dropEvent(DragHandler.itemBeingDragged, this.GetComponent<Object>());
            }
        
    }

    void Start()
    {
       // itemDroppedOn = this.gameObject.GetComponent<Object>();
    }
}
