using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    DaysManager daysManager;

    public GameObject menu;
    public GameObject game;

    public GameObject prologue;
    public Text prologueText;
    public float prologueDuration = 5.0f;

    public GameObject bedroom;

    public GameObject lampe;

    void Start () {
        daysManager = GameObject.FindGameObjectWithTag("DaysManager").GetComponent<DaysManager>();
	}
	

	void Update () {
	    
	}

    public void AffichePrologue(string phrase)
    {
        prologueText.text = phrase;
        StartCoroutine(PrologueCoroutine());
    }

    private IEnumerator PrologueCoroutine()
    {
        bedroom.SetActive(false);
        prologue.SetActive(true);
        yield return new WaitForSeconds(prologueDuration);
        prologue.SetActive(false);
        bedroom.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void AfficheGameOver()
    {
        prologueText.text = "You lose";
        StartCoroutine(EndCoroutine());
    }

    public void AfficheVictoire()
    {
        prologueText.text = "You win";
        StartCoroutine(EndCoroutine());
    }

    private IEnumerator EndCoroutine()
    {
        daysManager.ResetAllTimers();
        bedroom.SetActive(false);
        prologue.SetActive(true);
        yield return new WaitForSeconds(prologueDuration);
        game.SetActive(false);
        menu.SetActive(true);
        bedroom.SetActive(true);
        prologue.SetActive(false);
        lampe.SetActive(true);
    }
}
