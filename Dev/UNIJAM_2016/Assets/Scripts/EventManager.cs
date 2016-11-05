using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public Dictionary<int, Event[]> eventsOfDays;

    private Event[] eDayOne;
    private Event[] eDayTwo;
    private Event[] eDayThree;
    //private Event[] eDayFour;
    //private Event[] eDayFive;
    //private Event[] eDaySix;
    //private Event[] eDaySeven;
    //private Event[] eDayEight;

    private int nbEventDay1 = 1;
    private int nbEventDay2 = 0;
    private int nbEventDay3 = 0;
    //private int nbEventDay4 = 0;
    //private int nbEventDay5 = 0;
    //private int nbEventDay6 = 0;
    //private int nbEventDay7 = 0;
    //private int nbEventDay8 = 0;

    GameObject[] eventDayOneTabObjects;

    void Start()
    {
        eventsOfDays = new Dictionary<int, Event[]>();
        initiateDays();
        initiateEventsOfDays();
        BuildActions();
    }

    void Update()
    {

    }

    public void initiateEventsOfDays()
    {
        eventsOfDays.Add(0, eDayOne);
        eventsOfDays.Add(1, eDayTwo);
        eventsOfDays.Add(2, eDayThree);
        //eventsOfDays.Add(3, eDayFour);
        //eventsOfDays.Add(4, eDayFive);
        //eventsOfDays.Add(5, eDaySix);
        //eventsOfDays.Add(6, eDaySeven);
        //eventsOfDays.Add(7, eDayEight);

    }

    public void initiateDays()
    {
        eDayOne = new Event[nbEventDay1];
        eDayTwo = new Event[nbEventDay2];
        eDayThree = new Event[nbEventDay3];
        //eDayFour = new Event[nbEventDay4];
        //eDayFive = new Event[nbEventDay5];
        //eDaySix = new Event[nbEventDay6];
        //eDaySeven = new Event[nbEventDay7];
        //eDayEight = new Event[nbEventDay8];


        eventDayOneTabObjects = GameObject.FindGameObjectsWithTag("EventDay1");
        for (int i = 0; i < nbEventDay1; i++)
        {
            eDayOne[i] = eventDayOneTabObjects[i].GetComponent<Event>();
        }
        /*
          GameObject[] eventDayTwoTabObjects = GameObject.FindGameObjectsWithTag("EventDay2");
          for (int i = 0; i < nbEventDay2; i++)
          {
              eDayTwo[i] = eventDayTwoTabObjects[i].GetComponent<Event>();
          }

          GameObject[] eventDayThreeTabObjects = GameObject.FindGameObjectsWithTag("EventDay3");
          for (int i = 0; i < nbEventDay1; i++)
          {
              eDayThree[i] = eventDayThreeTabObjects[i].GetComponent<Event>();
          }

          GameObject[] eventDayFourTabObjects = GameObject.FindGameObjectsWithTag("EventDay4");
          for (int i = 0; i < nbEventDay4; i++)
          {
              eDayFour[i] = eventDayFourTabObjects[i].GetComponent<Event>();
          }

          GameObject[] eventDayFiveTabObjects = GameObject.FindGameObjectsWithTag("EventDay5");
          for (int i = 0; i < nbEventDay5; i++)
          {
              eDayFive[i] = eventDayFiveTabObjects[i].GetComponent<Event>();
          }

          GameObject[] eventDaySixTabObjects = GameObject.FindGameObjectsWithTag("EventDay6");
          for (int i = 0; i < nbEventDay6; i++)
          {
              eDaySix[i] = eventDaySixTabObjects[i].GetComponent<Event>();
          }

          GameObject[] eventDaySevenTabObjects = GameObject.FindGameObjectsWithTag("EventDay7");
          for (int i = 0; i < nbEventDay7; i++)
          {
              eDaySeven[i] = eventDayOneTabObjects[i].GetComponent<Event>();
          }
          
         GameObject[] eventDayEightTabObjects = GameObject.FindGameObjectsWithTag("EventDay8");
          for (int i = 0; i < nbEventDay8; i++)
          {
              eDayEight[i] = eventDayOneTabObjects[i].GetComponent<Event>();
          }
          
         GameObject[] eventDayNineTabObjects = GameObject.FindGameObjectsWithTag("EventDay9");
          for (int i = 0; i < nbEventDay9; i++)
          {
              eDayNine[i] = eventDayOneTabObjects[i].GetComponent<Event>();
          }*/
    }

    public void BuildActions()
    {
        eDayOne[0].Time = 10.0f;
        eDayOne[0].action = () => ActionOne0();
    }

    public void ActionOne0()
    {
        Debug.Log("0");
    }

    public void ActionOne1()
    {
        Debug.Log("1");
    }

    public void ActionOne2()
    {
        Debug.Log("2");
    }

    public void ActionOne3()
    {
        Debug.Log("3");
    }

    public void ResetEvents()
    {
        for (int i = 0; i < eDayOne.Length; i++)
        {
            eDayOne[i].AEteLance = false;
        }
    }
}
