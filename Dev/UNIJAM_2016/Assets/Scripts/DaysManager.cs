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
    

	// Use this for initialization
	void Start () {
        timerTab = new Timer[nmbDayMAX];
        prologueTab = new String[nmbDayMAX];
        //eventManager = GameObject.FindGameObjectWithTag("EventManager");

	}
	
	// Update is called once per frame
	void Update () {
	    
        if  (timerTab[mDay].Get() > timeMaxPerDay)
        {
            NextDay();
        }
        else
        {
            /*
            for (tous les events du jour n° mDay pas encore lancés) {
                if (timerTab[mDay].Get() > eventmanager.get(i).time) {
                    eventmanager.get(i).launch();
                }
            }
            */
        }
    }

    public void NextDay()
    {
        timerTab[mDay].Stop();
        timerTab[mDay].Reset();
        mDay++;
        //uiManager.AffichePrologue(prologueTab[mDay]);
        timerTab[mDay].LetsStart();
    }

    public void FirstDay()
    {
        //uiManager.AffichePrologue(prologueTab[mDay]);
        timerTab[mDay].LetsStart();
    }
}
