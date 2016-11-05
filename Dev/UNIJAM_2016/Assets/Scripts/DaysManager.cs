using UnityEngine;
using System.Collections;

public class DaysManagers : MonoBehaviour {

    int nmbDayMAX = 9;
    int mDay = 0;
    Timer[] timerTab;
    GameObject eventManager;

	// Use this for initialization
	void Start () {
        timerTab = new Timer[nmbDayMAX];
        //eventManager = GameObject.FindGameObjectWithTag("EventManager");

	}
	
	// Update is called once per frame
	void Update () {
	    /*
        for tous les events du jour n° mDay
            
        */
	}

    public void NextDay()
    {
        timerTab[mDay].Stop();
        timerTab[mDay].Reset();
        mDay++;
        timerTab[mDay].LetsStart();
    }
}
