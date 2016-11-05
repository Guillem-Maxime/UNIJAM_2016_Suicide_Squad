using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Object : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;

    private Vector3 initialPosition;

    public Vector3 getInitialPosition()
    {
        return initialPosition;
    }

    public LayerMask interactions;

	// Use this for initialization
	void Start () {
        initialPosition = new Vector3(0, 0, 0);
        this.transform.position = initialPosition;
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        if (Physics.Raycast(ray, out hit, 50f))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log(Input.mousePosition);
                this.transform.position = Input.mousePosition;
            }else if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                this.transform.position = initialPosition;
            }
        }
    }

}
