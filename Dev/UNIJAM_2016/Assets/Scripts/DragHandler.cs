using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;



public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private bool isDraggable = true;
    public bool getDraggable() { return isDraggable; }
    public void setDraggable(bool b) { isDraggable = b; }

    public static Object itemBeingDragged;
    private Vector3 fixPosition;
    public Vector3 getFixPosition() { return fixPosition; }
    public  void setFixPosition(Vector3 pos) { fixPosition = pos; }
    [SerializeField]
    //private CanvasGroup canvasGroup;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            itemBeingDragged = gameObject.GetComponent<Object>();
            fixPosition = transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;
        //this.gameObject.transform.position = newPosition;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = fixPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    #endregion


}
