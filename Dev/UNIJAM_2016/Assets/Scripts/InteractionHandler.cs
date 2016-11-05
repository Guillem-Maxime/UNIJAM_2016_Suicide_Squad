using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class InteractionHandler : MonoBehaviour {

    private UIManager uiManager;

	// Use this for initialization
	void Start ()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        foreach (DropHandler dropHandler in FindObjectsOfType<DropHandler>())
            dropHandler.dropEvent += DoubleInteraction;

        foreach (ClickHandler clickHandler in FindObjectsOfType<ClickHandler>())
            clickHandler.clickEvent += SimpleInteraction;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SimpleInteraction(Object itemClicked)
    {
        switch (itemClicked.getName())
        {
            case ("Radio"):
                soundBruit("radio1");
                printSentence("...Les forces de l'ordre tentent toujours de...");
                soundBruit("radio1");
                printSentence("...Les émeutes grossissent et se multiplient...");
                break;
            case ("fenetre"):
                printSentence("Je ferai mieux de ne pas me montrer c'est trop dangereux.");
                break;
            case ("PorteDehors"):
                printSentence("Mauvaise idée, je n'ai pas envie de me retrouver avec un zombie...");
                break;
            case ("PorteRemise"):
                printSentence("Ah c'est fermé...");
                break;
            case ("Barricade"):
                printSentence("Oh non ! Je dois rapidement trouver de quoi renforcer ma barricade !");
                break;
            case ("Robinet"):
                printSentence("J'ai toujours de l'eau mais il me faudrait un récipient.");
                break;
            case ("Chat"):
                printSentence("Où étais-tu passé ?");
                soundBruit("miaou");
                break;
            case ("Tiroir"):
                changeSprite(itemClicked, 1);
                itemClicked.gameObject.GetComponent<DragHandler>().setDraggable(false);
                //Instanciate barre milka
                break;
            default:
                printSentence("Rien ne se passe...");
                break;
        }
    }

    private void DoubleInteraction(Object itemDragged, Object itemDroppedOn)
    {

        switch (itemDragged.getName())
        {
            case ("BarreMilka"):
                switch (itemDroppedOn.getName())
                {
                    case ("Personnage"):
                        destroyItem(itemDragged);
                        AddFatigue(-20);
                        printSentence("Exactement ce dont j'avais besoin...");
                        break;
                    default:
                        printSentence("Rien ne se passe...");
                        break;
                }
            break;
            case ("Chaise"):
                switch (itemDroppedOn.getName())
                {
                    case ("Porte"):
                        setPosition(itemDroppedOn.transform.position, itemDragged);
                        changeSprite(itemDragged, 1);
                        AddDanger(-20);
                        printSentence("Ça devrait suffire à les retenir...");
                        break;
                    default:
                        printSentence("Rien ne se passe...");
                        break;
                }
                break;
            case ("Bouteille"):
                switch (itemDroppedOn.getName())
                {
                    case ("Robinet"):
                        changeSprite(itemDragged, 1);
                        printSentence("Au moins je n'aurai pas de problème de soif.");
                        break;
                    case ("Personnage"):
                        if (itemDragged.GetComponent<Image>().sprite == itemDragged.spriteList[1])
                        {
                            destroyItem(itemDragged);
                            AddFatigue(-20);
                            printSentence("Ça fait du bien.");
                        }
                            break;
                    default:
                        printSentence("Rien ne se passe...");
                        break;
                }
                break;


            case ("Gloves"):
                switch (itemDroppedOn.getName())
                {
                    case ("Rocky"):
                        changeSprite(itemDroppedOn, 1);
                        soundMusique("RockyMusique");
                        break;
                    default:
                        printSentence("Rien ne se passe...");
                        break;
                }

                break;
            case ("Apollo Creed"):
                switch (itemDroppedOn.getName())
                {
                    case ("Rocky"):
                        printSentence("You Win ! ");
                        destroyItem(itemDragged);
                        break;
                    default:
                        printSentence("Rien ne se passe...");
                        break;
                }
                break;
            case ("Adrienne"):
                switch (itemDroppedOn.getName())
                {
                    case ("Rocky"):
                        printSentence("AAADDDRRRRIIIIIEEEEEENNNNNNNEEEEEE !!!");
                        break;
                    default:
                        printSentence("Rien ne se passe...");
                        break;
                }
                break;
            default:
                printSentence("Rien ne se passe...");
                break;
        }
    }



    private void printSentence(string sentenceToPrint)
    {
        Debug.Log(sentenceToPrint);
        uiManager.Dialog(sentenceToPrint, 5.0f);
        //print sentence in UI
    }

    private void destroyItem(Object target)
    {
        Destroy(target.gameObject);
    }

    private void soundMusique(string name)
    {
        SoundManager.PlayMusique(name);
    }

    private void soundBruit(string name)
    {
        SoundManager.PlayBruitage(name);
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
        obj.gameObject.GetComponent<Image>().sprite = obj.spriteList[index];
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
