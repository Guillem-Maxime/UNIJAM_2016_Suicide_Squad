using UnityEngine;
using System.Collections;

public class CrazyLampe : MonoBehaviour {

    SpriteRenderer rend;
    Color initColor;
    Color targetColor = Color.yellow;
    public float duration = 1.0f;

    bool down = false;
    bool up = true;

    float t = 0;

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        initColor = rend.color;
	}
	
	// Update is called once per frame
	void Update () {
        rend.color = Color.Lerp(initColor, targetColor, t);
        if (up)
        {
            t += 0.02f;
            if (t >= duration)
            {
                down = true;
                up = false;
            }
        }
        else if (down)
        {
            t -= 0.02f;
            if (t <= 0.0f)
            {
                down = false;
                up = true;
            }
        }

	}
}
