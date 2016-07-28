using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public Vector3 pos;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        pos = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
