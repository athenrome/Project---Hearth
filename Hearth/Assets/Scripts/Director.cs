using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public Transform woodSpawn;

    public GameObject woodPrefab;

    public Waypoint characterEntry;
    public Waypoint forestExit;

    public List<Character> CharacterPool;

    float woodSpawnInterval; //time between wood drops

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(woodSpawnInterval <= 0)
        {
            GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation);
            woodSpawnInterval = 5f;
        }
        else
        {
            woodSpawnInterval -= Time.deltaTime;
        }

	
	}


}
