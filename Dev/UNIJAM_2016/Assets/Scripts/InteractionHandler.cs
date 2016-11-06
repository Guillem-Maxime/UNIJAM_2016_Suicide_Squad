using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class InteractionHandler : MonoBehaviour {

    private UIManager uiManager;
    private int mDay;

    // Use this for initialization
    void Start()
    {
        ObjectManager objectManager = GameObject.FindGameObjectWithTag("ObjectsManager").GetComponent<ObjectManager>();
        if (objectManager == null) Debug.LogError("pas de tag objectManager");
        objectManager.findObjectsEvent += FindObjects;
        mDay =  FindObjectOfType<DaysManager>().getMDay();
    }

    public void FindObjects()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if (uiManager == null) Debug.LogError("pas de tag uiManager");
        foreach (DropHandler dropHandler in FindObjectsOfType<DropHandler>())
        {
            dropHandler.dropEvent += DoubleInteraction;
        }


        foreach (ClickHandler clickHandler in FindObjectsOfType<ClickHandler>())
        {
            clickHandler.clickEvent += SimpleInteraction;
        }

    }

    private void SimpleInteraction(Object itemClicked)
    {
        switch (mDay)
        {
            case (0):
                SimpleInteractionDayOne(itemClicked);
                break;
            case (1):
                SimpleInteractionDayTwo(itemClicked);
                break;
            case (2):
                SimpleInteractionDayThree(itemClicked);
                break;
        }
    }

    private void SimpleInteractionDayOne(Object itemClicked) { 
        switch (itemClicked.getName())
        {
            case ("Radio"):
                changeSprite(itemClicked, 1);
                soundBruit("radio1");
                string str = "...Les forces de l'ordre tentent toujours de... \n ...Les émeutes grossissent et se multiplient...";
                printSentence(str);
                WaitReverse(5.0f, itemClicked, 0);
                break;
            case ("Barricade"):
                printSentence("Je ferai mieux de ne pas me montrer c'est trop dangereux.");
                break;
            case ("PorteDehors"):
                printSentence("Mauvaise idée, je n'ai pas envie de me retrouver avec un zombie...");
                //soundBruit("PorteFermée");
                break;
            case ("PorteRemise"):
                printSentence("Ah c'est fermé...");
                //soundBruit("PorteVerouillée");
                break;
            //case ("Barricade"):
            //    printSentence("Oh non ! Je dois rapidement trouver de quoi renforcer ma barricade !");
            //    break;
            case ("Robinet"):
                printSentence("J'ai toujours de l'eau mais il me faudrait un récipient.");
                break;
            case ("Chat"):
                printSentence("Où étais-tu passé ?");
                soundBruit("miaou");
                break;
            case ("Tiroir"):
                if(itemClicked.GetComponent<Image>().sprite == itemClicked.spriteList[0])
                {
                    changeSprite(itemClicked, 1);
                    ActivateObject("barreMilka", true);
                    //soundBruit("ouvertureTiroir");
                }else
                {
                    changeSprite(itemClicked, 0);
                    //soundBruit("fermetureTiroir");
                }
                break;
            case ("PorteManteaux"):
                printSentence("Je n'ai pas de veste, pour ce que ça pourrait me servir...");
                break;
            case ("Plaid"):
                printSentence("Je n'ai ni froid, ni envie de me cacher...");
                break;
            default:
                printSentence("Rien ne se passe...");
                break;
        }
    }

    private void SimpleInteractionDayTwo(Object itemClicked)
    {
        switch (itemClicked.getName())
        {
            case ("BallePingPong"):
                soundBruit("miaou");
                printSentence("Aide moi !");
                    break;
            case ("Carton"):
                if (itemClicked.GetComponent<Image>().sprite == itemClicked.spriteList[0])
                    changeSprite(itemClicked, 1);
                else
                    changeSprite(itemClicked, 0);
                break;
            case ("Radio"):
                changeSprite(itemClicked, 1);
                soundBruit("radio1");
                string str = "Aujourd'hui sur toute la région, un temps ensoleillé, \n avec possibilité de nuages et des températures douces";
                printSentence(str);
                WaitReverse(5.0f, itemClicked, 0);
                break;
            case ("PorteDehors"):
                printSentence("Il faut que je répare vite !");
                break;
            case ("Monstre"):
                printSentence("Au secours !!");
                break;
            default:
                printSentence("Rien ne se passe...");
                break;

        }
    }

    private void SimpleInteractionDayThree(Object itemClicked)
    {

    }

    private void DoubleInteraction(Object itemDragged, Object itemDroppedOn)
    {
        switch (mDay)
        {
            case (0):
                DoubleInteractionDayOne(itemDragged, itemDroppedOn);
                break;
            case (1):
                DoubleInteractionDayTwo(itemDragged, itemDroppedOn);
                break;
            case (2):
                DoubleInteractionDayThree(itemDragged, itemDroppedOn);
                break;
        }
    }

    private void DoubleInteractionDayOne(Object itemDragged, Object itemDroppedOn) { 
        switch (itemDragged.getName())
        {
            case ("BarreMilka"):
                switch (itemDroppedOn.getName())
                {
                    case ("Personnage"):
                        destroyItem(itemDragged);
                        AddMoral(+35);
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
                    case ("PorteDehors"):
                        setPosition(itemDroppedOn.transform.position, itemDragged);
                        printSentence("Ça devrait suffire à les retenir...");
                        AddDanger(-30);
                       // changeSprite(itemDragged, 1);
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
                        changeSprite(itemDroppedOn, 1);
                        printSentence("Au moins je n'aurai pas de problème de soif.");
                        WaitReverse(2.0f, itemDroppedOn, 0);
                        break;
                    case ("Personnage"):
                        if (itemDragged.GetComponent<Image>().sprite == itemDragged.spriteList[1])
                        {
                            destroyItem(itemDragged);
                            AddFatigue(10);
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
                        soundBruit("miaou");
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

    private void DoubleInteractionDayTwo(Object itemDragged, Object itemDroppedOn)
    {
        switch (itemDragged.getName())
        {
            case ("Cartes"):
                if(itemDroppedOn.getName() == "Personnage")
                {
                    printSentence("On jouait souvent avec, tous les deux...");
                    AddMoral(+35);
                }
                else
                    printSentence("Rien ne se passe...");
                break;
            case ("Photos"):
                if (itemDroppedOn.getName() == "Personnage")
                {
                    printSentence("Mon frère, mes parents et moi, c'était il y a longtemps ... on s'était bien amusé");
                    AddMoral(+35);
                }
                else
                    printSentence("Rien ne se passe...");
                break;
            case ("Veste"):
                if (itemDroppedOn.getName() == "PorteManteaux")
                {
                    printSentence("C'était celle de mon frère.. il la portait à l'époque.");
                    changeSprite(itemDragged, 1);

                }
                else
                    printSentence("Rien ne se passe...");
                break;
            default:
                printSentence("Rien ne se passe...");
                break;
        }
    }

    private void DoubleInteractionDayThree(Object itemDragged, Object itemDroppedOn)
    {

    }

    private void printSentence(string sentenceToPrint)
    {
        uiManager.Dialog(sentenceToPrint, 5.0f);
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

    private void AddMoral(int var)
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
        obj.gameObject.GetComponent<DragHandler>().setFixPosition(newPosition);
    }

    private void changeCharacterSprite(Character character, int index)
    {
        character.GetComponent<SpriteRenderer>().sprite = character.spriteList[index];
    }
    
    private void ActivateObject(string name, bool isActive)
    {
        ObjectManager objectManager = FindObjectOfType<ObjectManager>();
        objectManager.setSpecificActive(objectManager.searchInList(name), isActive);
    }

    private void GotAMatch()
    {
        //Apart from being an awesome chick Corea Track, it does neat things with light and stuff
    }

    private void MayTheFourthBeWithYou()
    {
        //Big animation on fourth day
    }

    private void displayImage(string name)
    {
        //Display a big image
    }

    private void WaitReverse(float seconds, Object item, int nbrSprite)
    {
        StartCoroutine(WaitCoroutineReverse(seconds, item, nbrSprite));
    }

    private IEnumerator WaitCoroutineReverse(float seconds, Object item, int nbrSprite)
    {
        yield return new WaitForSeconds(seconds);
        changeSprite(item, nbrSprite);

    }
}
