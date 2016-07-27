using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Camera cam;

    public Vector3 mousePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = GetMousePosition();
        
	
	}

    Vector3 GetMousePosition()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);

        return pos;
    }
}
