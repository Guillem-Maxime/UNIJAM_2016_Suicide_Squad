using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {

    private string title; 

    private float time;

    public float Time
    {
        get;
        set;
    }

    private ObjectManager om;

    private GaugeManager gm;

    private UIManager um;

    public void writeDialogue(string phrase)
    {

    }

	// Use this for initialization
	void Start () {
        //GameObject.FindGameObjectWithTag("GaugeManager").GetComponent<GaugeManager>();
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
