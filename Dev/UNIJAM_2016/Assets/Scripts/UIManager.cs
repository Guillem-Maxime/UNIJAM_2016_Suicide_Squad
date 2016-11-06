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

    public SpriteRenderer INTRO;
    public Sprite blackSprite;
    public Sprite introSprite;


    void Start () {
        daysManager = GameObject.FindGameObjectWithTag("DaysManager").GetComponent<DaysManager>();
        SoundManager.PlayMusique("salad");
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

    public void AfficheMultiplePrologue(string[] phrases, float[] waits, int n)
    {
        StartCoroutine(MultipleCoroutine(phrases, waits, n));
    }

    private IEnumerator PrologueCoroutine(float prologueDuration)
    {
        bedroom.SetActive(false);
        prologue.SetActive(true);
        yield return new WaitForSeconds(prologueDuration);
        prologue.SetActive(false);
        bedroom.SetActive(true);

    }



    private IEnumerator MultipleCoroutine(string[] phrases, float[] waits, int n)
    {
        float x = 0;
        bedroom.SetActive(false);
        prologue.SetActive(true);
        for (int i = 0; i < n; i++)
        {
            prologueText.text = phrases[i];
            if (i == n - 1)
            {
                INTRO.sprite = introSprite;
            }

            
            while (x < 1.0f)
            {
                x = x + 0.05f;
                if (i == n - 1)
                {
                    INTRO.color = new Vector4(prologueText.color.r, prologueText.color.b, prologueText.color.g, x);
                }
                else {
                    prologueText.color = new Vector4(prologueText.color.r, prologueText.color.b, prologueText.color.g, x);
                }
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(waits[i] - 1.0f);


            while (x > 0)
            {
                x = x - 0.05f;
                if (i == n - 1)
                {
                    INTRO.color = new Vector4(prologueText.color.r, prologueText.color.b, prologueText.color.g, x);
                }
                else {
                    prologueText.color = new Vector4(prologueText.color.r, prologueText.color.b, prologueText.color.g, x);
                }
                yield return new WaitForSeconds(0.05f);
            }

            if (i == n - 1)
            {
                INTRO.sprite = blackSprite;
            }
        }
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
        SoundManager.ChangeMusique("salad");
    }

    public void fadeIn(GameObject o)
    {
        SpriteRenderer rend = o.GetComponent<SpriteRenderer>();
        StartCoroutine(FadingInCoroutine(rend));
    }

    private IEnumerator FadingInCoroutine(SpriteRenderer rend)
    {
        float x = 0;
        while (x < 1.0f)
        {
            x = x + 0.05f;
            rend.color = new Vector4(rend.color.r, rend.color.b, rend.color.g, x);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void fadeOut(GameObject o)
    {
        SpriteRenderer rend = o.GetComponent<SpriteRenderer>();
        StartCoroutine(FadingOutCoroutine(rend));
    }

    private IEnumerator FadingOutCoroutine(SpriteRenderer rend)
    {
        float x = 1;
        while (x > 0)
        {
            x = x - 0.05f;
            rend.color = new Vector4(rend.color.r, rend.color.b, rend.color.g, x);
            yield return new WaitForSeconds(0.05f);
        }

    }

}
