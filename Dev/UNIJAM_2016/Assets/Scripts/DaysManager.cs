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
        prologueTab[0] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[1] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[2] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[3] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[4] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[5] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[6] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[7] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        prologueTab[8] = "On n'ose jamais mourir.\r\n On ose tenir à la vie.\r\n lol.";
        
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
            for (int i = 0; i < eventManager.eventsOfDays[mDay].Length; i++) {
                if (timerTab[mDay].Get() > eventManager.eventsOfDays[mDay][i].Time)
                {
                    eventManager.eventsOfDays[mDay][i].launch();
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
            timerTab[mDay].LetsStart();
        }
        else
        {
            //uiManager -> you win ! 
        }
    }

    public void FirstDay()
    {
        mDay = 0;
        uiManager.AffichePrologue(prologueTab[mDay]);
        timerTab[mDay].LetsStart();
    }
}
