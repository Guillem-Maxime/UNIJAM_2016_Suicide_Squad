using UnityEngine;
using System.Collections;
using System;

public class DaysManager : MonoBehaviour {

    float timeMaxPerDay = 150.0f;
    int nmbDayMAX = 9;
    int mDay = 0;
    Timer[] timerTab;
    String[] prologueTab;
    EventManager eventManager;
    UIManager uiManager;

    public SpriteRenderer lumieresRenderer;
    public Sprite lumieresOn;
    public Sprite lumieresOff;
    

	void Start () {
        timerTab = new Timer[nmbDayMAX];
        GameObject[] timerTabObjects = GameObject.FindGameObjectsWithTag("Timer");
        for (int i = 0; i < nmbDayMAX; i++)
        {
            timerTab[i] = timerTabObjects[i].GetComponent<Timer>();
        }

        prologueTab = new String[nmbDayMAX];
        prologueTab[0] = "Aujourd'hui, rien ne va plus. Le monde est trop dangereux, des zombies partout... \r\n Je dois rester chez moi. Les murs sont froids, je me sens partir un peu plus chaque jour.\r\n Combien de temps vais-je tenir ?";
        prologueTab[1] = "Je suis le texte du deuxième jour";
        prologueTab[2] = "Je suis le texte du troisième jour";
        prologueTab[3] = "Je suis le texte du cinquième jour.\r\n Non, j'ai menti.";
        prologueTab[4] = "Je suis le vrai texte du cinquième jour.";
        prologueTab[5] = "Je suis le texte du sixième jour.";
        prologueTab[6] = "Je suis le texte du septième jour.";
        prologueTab[7] = "Je suis le texte du huitième jour.";
        prologueTab[8] = "Je suis le texte du dernier jour.";
        
        eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
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
        if (mDay + 1 < nmbDayMAX)
        {
            timerTab[mDay].Stop();
            timerTab[mDay].Reset();
            mDay++;
            uiManager.AffichePrologue(prologueTab[mDay]);
            timerTab[mDay].Set(-uiManager.prologueDuration);
            timerTab[mDay].LetsStart();
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
        uiManager.AffichePrologue(prologueTab[mDay]);
        timerTab[mDay].Set(-uiManager.prologueDuration);
        timerTab[mDay].LetsStart();
        lumieresRenderer.sprite = lumieresOn;
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
    }
}
