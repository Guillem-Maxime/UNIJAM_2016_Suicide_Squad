using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public GameObject menu;
    public GameObject game;

    public GameObject prologue;
    public Text prologueText;
    float prologueDuration = 10.0f;

    public GameObject bedroom;

    void Start () {
	
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
}
