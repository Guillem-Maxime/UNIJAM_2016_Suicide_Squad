using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GaugeManager : MonoBehaviour {

    UIManager uiManager;

    int dangerMAX = 100;
    int danger;
    int fatigueMAX = 100;
    int fatigue;

    public Slider dangerSlider;
    public Slider fatigueSlider;

    

	void Start () {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        danger = dangerMAX / 2;
        fatigue = fatigueMAX / 2;
	}
	
	void Update () {
	    if (danger == 100 || fatigue == 100)
        {
            uiManager.AfficheGameOver();
            danger = dangerMAX / 2;
            fatigue = fatigueMAX / 2;
        }
        dangerSlider.value = danger;
        fatigueSlider.value = fatigue;
    }

    public void AddDanger(int var)
    {
        danger += var; 
        if (danger < 0)
        {
            danger = 0;
        } 
        else if (danger > 100)
        {
            danger = 100;
        }
    }

    public void AddFatigue(int var)
    {
        fatigue += var;
        if (fatigue < 0)
        {
            fatigue = 0;
        }
        else if (fatigue > 100)
        {
            fatigue = 100;
        }
    }

}
