using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    public List<Character> CharacterPool;

    public GameObject characterPrefab;

    public Waypoint characterEntry;
    public Waypoint forestExit;

    public List<Waypoint> closePoints;//waypoints closest to the fire
    public List<Waypoint> midPoints;
    public List<Waypoint> farPoints;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
