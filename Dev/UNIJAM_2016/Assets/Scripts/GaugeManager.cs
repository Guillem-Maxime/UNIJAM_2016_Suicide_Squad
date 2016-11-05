using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour {

    UIManager uiManager;
    int dangerMAX = 100;
    int danger;
    int fatigueMAX = 100;
    int fatigue;

    Slider dangerSlider;
    Slider fatigueSlider;

    DaysManager daysManager;

	void Start () {
        danger = dangerMAX / 2;
        fatigue = fatigueMAX / 2;
	}
	
	void Update () {
	    if (danger == 100 || fatigue == 100)
        {
            //uiManager --> affichage du gameOver
            daysManager.FirstDay();
            danger = dangerMAX / 2;
            fatigue = fatigueMAX / 2;
        }
	}

    public void AddDanger(int var)
    {
        danger += var;
        dangerSlider.value = danger;
    }

    public void AddFatigue(int var)
    {
        fatigue += var;
        fatigueSlider.value = fatigue;
    }

}
