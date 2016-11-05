using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour {

    public Sprite sprite1 = null;
    public Sprite sprite2 = null;
    public Sprite sprite3 = null;
    public Sprite sprite4 = null;
    public Sprite sprite5 = null;

    Sprite[] sprites;

    Image srenderer;

    public float timeBetweenSprites = 0.5f;
    float nextTime = 0;

    int i = 0;

	// Use this for initialization
	void Start () {
        sprites = new Sprite[5];
        sprites[0] = sprite1;
        sprites[1] = sprite2;
        sprites[2] = sprite3;
        sprites[3] = sprite4;
        sprites[4] = sprite5;

        srenderer = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (nextTime < Time.time)
        {
            i = (i + 1) % sprites.Length;
<<<<<<< HEAD
            //Debug.Log(sprites[i]);
=======
>>>>>>> b42a1e9db6cb4688d9e17a60326c07f1e1444b3f
            if (sprites[i] != null)
            {
                srenderer.sprite = sprites[i];
            }
            nextTime = Time.time + timeBetweenSprites;
        }
	}
}
