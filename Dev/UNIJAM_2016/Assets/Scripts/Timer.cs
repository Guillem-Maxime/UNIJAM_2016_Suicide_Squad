using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float mTime = 0;
    bool isActivated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (isActivated)
        {
            mTime += Time.deltaTime;
        }
        Debug.Log(mTime);
	}

    public void LetsStart()
    {
        isActivated = true;
    }

    public void Stop()
    {
        isActivated = false;
    }

    public void Reset()
    {
        mTime = 0;
    }

    public float Get()
    {
        return mTime;
    }

}
