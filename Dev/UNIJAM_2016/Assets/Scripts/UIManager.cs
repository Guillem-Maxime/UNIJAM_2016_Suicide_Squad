using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    DaysManager daysManager;

    public GameObject menu;
    public GameObject game;

    public GameObject prologue;
    public Text prologueText;
    public float BasicDuration = 13.0f;

    public GameObject bedroom;

    public GameObject lampe;

    public GameObject DialogBox;
    public Text DialogText;

    void Start () {
        daysManager = GameObject.FindGameObjectWithTag("DaysManager").GetComponent<DaysManager>();
	}
	

	void Update () {
	    
	}

    public void Dialog(string phrase, float duration)
    {
        StartCoroutine(DialogCoroutine(phrase, duration));
    }

    private IEnumerator DialogCoroutine(string phrase, float duration)
    {
        DialogBox.SetActive(true);
        DialogText.text = phrase;
        yield return new WaitForSeconds(duration);
        DialogBox.SetActive(false);
    }

    public void AffichePrologue(string phrase, float prologueDuration = 13.0f)
    {
        prologueText.text = phrase;
        StartCoroutine(PrologueCoroutine(prologueDuration));
    }

    public void AfficheMultiplePrologue(string[] phrases, int n, float prologueDuration = 8.0f)
    {
        StartCoroutine(MultipleCoroutine(phrases, n, prologueDuration));
    }

    private IEnumerator PrologueCoroutine(float prologueDuration)
    {
        bedroom.SetActive(false);
        prologue.SetActive(true);
        yield return new WaitForSeconds(prologueDuration);
        prologue.SetActive(false);
        bedroom.SetActive(true);
    }

    private IEnumerator MultipleCoroutine(string[] phrases, int n, float prologueDuration)
    {
        bedroom.SetActive(false);
        prologue.SetActive(true);
        for (int i = 0; i < n; i++)
        {
            prologueText.text = phrases[i];
            yield return new WaitForSeconds(prologueDuration);
        }
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
        yield return new WaitForSeconds(BasicDuration);
        game.SetActive(false);
        menu.SetActive(true);
        bedroom.SetActive(true);
        prologue.SetActive(false);
        lampe.SetActive(true);
    }
}
