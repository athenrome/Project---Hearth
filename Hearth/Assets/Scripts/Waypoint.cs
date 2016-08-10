using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {



    public Vector3 pos;

    public bool locked;

    public PointType type;

	// Use this for initialization
	void Start () {
        pos = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public enum PointType
{
    FirepitSlot,
    EntryPoint,
    ForestPoint,
    WoodPile,
}
