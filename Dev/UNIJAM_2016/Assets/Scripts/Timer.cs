using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    float mTime = 0;
    bool isActivated = false;

	void Start () {
	
	}
	
	void Update () {
	    if (isActivated)
        {
            mTime += Time.deltaTime;
        }
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

    public void Set(float t)
    {
        mTime = t;
    }

}
