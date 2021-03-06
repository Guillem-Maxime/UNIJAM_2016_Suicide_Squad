﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

    UIManager uiManager;
    GaugeManager gaugeManager;

    public GameObject chat;
    public GameObject barricade;

    public Dictionary<int, Event[]> eventsOfDays;

    private Event[] eDayOne;
    private Event[] eDayTwo;
    private Event[] eDayThree;
    //private Event[] eDayFour;
    //private Event[] eDayFive;
    //private Event[] eDaySix;
    //private Event[] eDaySeven;
    //private Event[] eDayEight;

    private int nbEventDay1 = 4;
    private int nbEventDay2 = 1;
    private int nbEventDay3 = 0;
    //private int nbEventDay4 = 0;
    //private int nbEventDay5 = 0;
    //private int nbEventDay6 = 0;
    //private int nbEventDay7 = 0;
    //private int nbEventDay8 = 0;

    GameObject[] eventDayOneTabObjects;
    GameObject[] eventDayTwoTabObjects;
    GameObject[] eventDayThreeTabObjects;

    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        gaugeManager = GameObject.FindGameObjectWithTag("GaugeManager").GetComponent<GaugeManager>();
        eventsOfDays = new Dictionary<int, Event[]>();
        initiateDays();
        initiateEventsOfDays();
        BuildActions();
        chat.SetActive(false);
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
        GameObject[] eventDayTwoTabObjects = GameObject.FindGameObjectsWithTag("EventDay2");
        for (int i = 0; i < nbEventDay2; i++)
        {
            eDayTwo[i] = eventDayTwoTabObjects[i].GetComponent<Event>();
        }
        /*
        GameObject[] eventDayThreeTabObjects = GameObject.FindGameObjectsWithTag("EventDay3");
        for (int i = 0; i < nbEventDay3; i++)
        {
            eDayThree[i] = eventDayThreeTabObjects[i].GetComponent<Event>();
        }
/*
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
        eDayOne[0].Time = 45.0f;
        eDayOne[0].action = () => ActionOne0();

        eDayOne[1].Time = 20.0f;
        eDayOne[1].action = () => ActionOne1();

        eDayOne[2].Time = 110.0f;
        eDayOne[2].action = () => ActionOne2();

        eDayOne[3].Time = 115.0f;
        eDayOne[3].action = () => ActionOne3();

        eDayTwo[0].Time = 0.01f;
        eDayTwo[0].action = () => ActionTwo0();

        /*eDayThree[0].Time = 45.0f;
        eDayThree[0].action = () => ActionOne0();

        eDayThree[1].Time = 20.0f;
        eDayThree[1].action = () => ActionOne1();

        eDayThree[2].Time = 110.0f;
        eDayThree[2].action = () => ActionOne2();*/


    }

    public void ActionOne0()
    {
        uiManager.Dialog("Oh non! Je dois rapidement trouver de quoi renforcer\r\n ma barricade !", 5.0f);
        barricade.SetActive(false);
        gaugeManager.AddDanger(20);
    }

    public void ActionOne1()
    {
        uiManager.Dialog("*grésillement* Aujourd'hui, le temps sera pluvieux sur tout le pays.\r\n Le vent sera fort et des *grésillements* nous vous conseillons de \r\n rester chez vous !", 15.0f);
        SoundManager.PlayBruitage("radio1");
    }

    public void ActionOne2()
    {
        uiManager.Dialog("Qu'est-ce que c'est que ça ?", 3.0f);
        SoundManager.PlayBruitage("miaou");
        chat.SetActive(true);
    }

    public void ActionOne3()
    {
        uiManager.Dialog("Salut toi ! Qu'est-ce que tu faisais là-dedans ?", 5.0f);
    }

    public void ActionTwo0()
    {
        uiManager.Dialog("Laisse-moi !", 5.0f);
    }

    public void ResetEvents()
    {
        for (int i = 0; i < eDayOne.Length; i++)
        {
            eDayOne[i].AEteLance = false;
        }
        for (int i = 0; i < eDayTwo.Length; i++)
        {
            eDayTwo[i].AEteLance = false;
        }

        chat.SetActive(false);
    }
}
