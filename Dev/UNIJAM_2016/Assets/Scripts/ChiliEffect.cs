using UnityEngine;
using System.Collections;

public class ChiliEffect : MonoBehaviour {

    public float intensity = 30.0f;
    float x;
    float y;
    Vector3 varVec;
    Vector3 initpos;

    Vector3 targetPos;

	void Start () {
        initpos = transform.position;
        targetPos = initpos;
	}
	
	void Update () {
        if (Vector3.Distance(targetPos,transform.position) < 1.0f)
        {
            transform.position = initpos;
            x = Random.Range(-1.0f, 1.0f);
            y = Random.Range(-1.0f, 1.0f);
            varVec = new Vector3(x, y, 0);
            targetPos = initpos + varVec;
            transform.position += Time.deltaTime * intensity * varVec;
        }
        else {
            transform.position += + Time.deltaTime * intensity * varVec;
        }

	}
}
