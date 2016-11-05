using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ClickHandler : MonoBehaviour
{

    public delegate void ClickDelegate(Object itemClicked);

    public event ClickDelegate clickEvent;

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if(clickEvent != null)
                {
                    clickEvent(this.GetComponent<Object>());
                }
            }
        }
    }



}
