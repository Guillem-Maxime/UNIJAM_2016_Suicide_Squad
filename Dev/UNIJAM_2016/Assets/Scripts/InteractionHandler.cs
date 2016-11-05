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
            case ("Gloves"):
                switch (itemCollided.getName())
                {
                    case ("Rocky"):
                        changeSprite(itemCollided, 1);
                        break;
                }

                break;
            case ("Apollo Creed"):
                switch (itemCollided.getName())
                {
                    case ("Rocky"):
                        printSentence("You Win ! ");
                        destroyItem(itemDragged);
                        break;
                }
                break;
            case ("Stairs"):
                switch (itemCollided.getName())
                {
                    case ("Rocky"):
                        //do something
                        break;
                }
                break;
            case ("Adrienne"):
                switch (itemCollided.getName())
                {
                    case ("Rocky"):
                        printSentence("AAADDDRRRRIIIIIEEEEEENNNNNNNEEEEEE !!!");
                        break;
                }
                break;
            default:
                //no interaction
                break;
        }
    }



    private void printSentence(string sentenceToPrint)
    {
        Debug.Log(sentenceToPrint);
        //print sentence in UI
    }

    private void destroyItem(Object target)
    {
        Destroy(target);
    }

    private void sound()
    {
        //launch sound
    }

    public delegate void ChangeGaugeDelegate(int var);

    public event ChangeGaugeDelegate ChangeDangerEvent;
    public event ChangeGaugeDelegate ChangeFatigueEvent;

    private void AddDanger(int var)
    {
        if (ChangeDangerEvent != null)
        {
            ChangeDangerEvent(var);
        }
    }

    private void AddFatigue(int var)
    {
        if (ChangeFatigueEvent != null)
        {
            ChangeFatigueEvent(var);
        }
    }

    private void changeSprite(Object obj, int index)
    {
        obj.GetComponent<SpriteRenderer>().sprite = obj.spriteList[index];
    }

    private void translateObject(Vector3 positionToTranslate, Object obj)
    {
        obj.transform.Translate(positionToTranslate);
    }

    private void setPosition(Vector3 newPosition, Object obj)
    {
        obj.transform.position = newPosition;
    }

    private void changeCharacterSprite(Character character, int index)
    {
        character.GetComponent<SpriteRenderer>().sprite = character.spriteList[index];
    }
    
    private void InstanciateObject(Object objectToInstanciate)
    {
        //Object to Instanciate
    }

    private void GotAMatch()
    {
        //Apart from being an awesome chick Corea Track, it does neat things with light and stuff
    }

    private void MayTheFourthBeWithYou()
    {
        //Big animation on fourth day
    }
}
