using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlightFantasy : MonoBehaviour {

    public Sprite h_sprite;
    public Sprite sprite;
    public Sprite h_sprite2;
    public Sprite sprite2;
    public Sprite h_sprite3;
    public Sprite sprite3;

    Sprite[] h_sprites;
    Sprite[] sprites;

    int etat = 0;
    Image image;

	void Start () {
        image = GetComponent<Image>();

        h_sprites = new Sprite[3];
        h_sprites[0] = h_sprite;
        h_sprites[1] = h_sprite2;
        h_sprites[2] = h_sprite3;

        sprites = new Sprite[3];
        sprites[0] = sprite;
        sprites[1] = sprite2;
        sprites[2] = sprite3;
	}
	

	void Update () {
        if (image.sprite == null)
        {

        }
	    else if (image.sprite == h_sprites[0] || image.sprite == sprites[0])
        {
            etat = 0;
        }
        else if (image.sprite == h_sprites[1] || image.sprite == sprites[1])
        {
            etat = 1;
        }
        else if (image.sprite == h_sprites[2] || image.sprite == sprites[2]) {
            etat = 2;
        }
	}

    public void highlightOn()
    {
        image.sprite = h_sprites[etat];
        Debug.Log("Highlight ON : etat " + etat + " et sprite " + image.sprite);
    }

    public void highlightOff()
    {
        image.sprite = sprites[etat];
        Debug.Log("Highlight OFF : etat " + etat + " et sprite " + image.sprite);
    }
}
