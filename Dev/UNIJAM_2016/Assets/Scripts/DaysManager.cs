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
    

	void Start () {
        timerTab = new Timer[nmbDayMAX];
        GameObject[] timerTabObjects = GameObject.FindGameObjectsWithTag("Timer");
        for (int i = 0; i < nmbDayMAX; i++)
        {
            timerTab[i] = timerTabObjects[i].GetComponent<Timer>();
        }

        prologueTab = new String[nmbDayMAX];
        prologueTab[0] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n Eh oui!";
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
    }
	
	void Update () {
        
        if  (timerTab[mDay].Get() > timeMaxPerDay)
        {
            NextDay();
        }
        else
        {
            /*for (tous les events du jour n° mDay pas encore lancés) {
                if (timerTab[mDay].Get() > eventmanager.get(i).time) {
                    eventmanager.get(i).launch();
                }
            }*/
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
        mDay = 0;
        uiManager.AffichePrologue(prologueTab[mDay]);
        timerTab[mDay].Set(-uiManager.prologueDuration);
        timerTab[mDay].LetsStart();
    }
}
