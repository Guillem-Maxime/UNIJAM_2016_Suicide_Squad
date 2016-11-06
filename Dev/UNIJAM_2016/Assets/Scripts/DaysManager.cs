using UnityEngine;
using System.Collections;
using System;

public class DaysManager : MonoBehaviour {

    float timeMaxPerDay = 150.0f;
    int nmbDayMAX = 3;
    int mDay = 0;
    public int getMDay() { return mDay; }
    Timer[] timerTab;
    String[] prologueTab;
    EventManager eventManager;
    UIManager uiManager;
    private ObjectManager objectManager;

    public SpriteRenderer lumieresRenderer;
    public Sprite lumieresOn;
    public Sprite lumieresOff;

    string[] parts;
    float[] waits;

	void Start () {
        timerTab = new Timer[nmbDayMAX];
        GameObject[] timerTabObjects = GameObject.FindGameObjectsWithTag("Timer");
        for (int i = 0; i < nmbDayMAX; i++)
        {
            timerTab[i] = timerTabObjects[i].GetComponent<Timer>();
        }

        prologueTab = new String[nmbDayMAX];
        prologueTab[0] = "Aujourd'hui, rien ne va. Le monde est trop dangereux, des zombies partout... \r\n Je dois rester chez moi. Les murs sont froids, je me sens partir un peu plus chaque jour.\r\n Combien de temps vais-je tenir ?";

        prologueTab[1] = "Jour 2";
        prologueTab[2] = "Jour 3";
        /*prologueTab[3] = "Je suis le texte du cinquième jour.\r\n Non, j'ai menti.";
        prologueTab[4] = "Je suis le vrai texte du cinquième jour.";
        prologueTab[5] = "Je suis le texte du sixième jour.";
        prologueTab[6] = "Je suis le texte du septième jour.";
        prologueTab[7] = "Je suis le texte du huitième jour.";
        prologueTab[8] = "Je suis le texte du dernier jour.";*/

        parts = new string[7];
        waits = new float[7];
        parts[0] = "Aujourd'hui, rien ne va.";
        waits[0] = 2.0f;
        parts[1] = "Le monde est trop dangereux, il y a des zombies partout...\r\n Je dois rester chez moi.";
        waits[1] = 4.0f;
        parts[2] = "Les murs sont froids.\r\n Je me sens partir un peu plus chaque jour.";
        waits[2] = 2.0f;
        parts[3] = "Combien de temps vais-je tenir ainsi ?";
        waits[3] = 2.0f;
        parts[4] = "";
        waits[4] = 0.5f;
        parts[5] = "Les semi-affordants vous présentent...";
        waits[5] = 2.0f;
        parts[6] = "";
        waits[6] = 4.0f;

        
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        objectManager = GameObject.FindGameObjectWithTag("ObjectsManager").GetComponent<ObjectManager>();
        lumieresRenderer.sprite = lumieresOff;
    }
	
	void Update () {
        
        if  (timerTab[mDay].Get() > timeMaxPerDay)
        {
            NextDay();
        }
        else
        {
            for (int i = 0; i < eventManager.eventsOfDays[mDay].Length; i++) {
                if (timerTab[mDay].Get() > eventManager.eventsOfDays[mDay][i].Time && !(eventManager.eventsOfDays[mDay][i].AEteLance))
                {
                    eventManager.eventsOfDays[mDay][i].launch();
                    eventManager.eventsOfDays[mDay][i].AEteLance = true;
                }
            }
        }
    }

    public void NextDay()
    {
        //objectManager.unloadSceneObjects();

        if (mDay + 1 < nmbDayMAX)
        {
            timerTab[mDay].Stop();
            timerTab[mDay].Reset();
            mDay++;
            uiManager.AffichePrologue(prologueTab[mDay]);
            timerTab[mDay].Set(-uiManager.BasicDuration);
            timerTab[mDay].LetsStart();
            objectManager.loadSceneObjects(mDay);
        }
        else
        {
            uiManager.AfficheVictoire();
        }
    }

    public void FirstDay()
    {
        SoundManager.PlayMusique("saddest");
        mDay = 0;
        uiManager.AfficheMultiplePrologue(parts, waits, 7);
    }

    public void ResetAllTimers()
    {
        for (int i = 0; i < timerTab.Length; i++)
        {
            timerTab[i].Stop();
            timerTab[i].Reset();
        }
        eventManager.BuildActions();
        eventManager.ResetEvents();
        lumieresRenderer.sprite = lumieresOff;
        SoundManager.StopMusique();
        objectManager.setAllObjectsActive(false);
    }

    public void GameStart()
    {
        timerTab[mDay].LetsStart();
        lumieresRenderer.sprite = lumieresOn;
        objectManager.loadSceneObjects(0);
    }
}
