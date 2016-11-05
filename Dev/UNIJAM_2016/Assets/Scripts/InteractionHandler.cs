using UnityEngine;
using System.Collections;

public class InteractionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach(DragHandler dragHandler in FindObjectsOfType<DragHandler>())
            dragHandler.CollisionEvent += Interaction;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Interaction(Object itemDragged, Object itemCollided)
    {
        switch (itemDragged.getName())
        {
            case ():
                //do something
                break;
            case ():
                //do something
                break;
            default:
                //no interaction
                break;
        }
    }

    private void printSentence()
    {
        //print sentence in UI
    }

    private void destroyItem(Object target)
    {
        //destroy target
    }

    private void sound()
    {
        //launch sound
    }
}
