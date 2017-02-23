using UnityEngine;
using System.Collections;

public class Right : MonoBehaviour {

    public GameObject racket;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
            racket.GetComponent<Rocket>().MoveRight();

    }
}
