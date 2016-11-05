using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{

    public delegate void ClickDelegate(Object itemClicked);

    public event ClickDelegate clickEvent;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(clickEvent != null)
        {
            clickEvent(this.gameObject.GetComponent<Object>());
        }
    }
}
