using UnityEngine;
using System.Collections.Generic;

public class WoodPile : MonoBehaviour {

    public int woodCount = 0;
    public int maxWood = 5;

    public List<Transform> woodPileSpawns;

    public GameObject woodModel;//used to show wood amount in pile doesnt not have script attached
    public GameObject woodPrefab;//used to spawn dragable wood

    public Transform woodSpawn;


	// Use this for initialization
	void Start () {
        AddWood();
        AddWood();
        AddWood();
        AddWood();
        AddWood();
        AddWood();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void RemoveWood()
    {
        if (woodCount >= 1)
        {
            GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation);
            woodCount--;
            Debug.Log("Spawn Log");
        }
    }

    void AddWood()
    {
        if(woodCount < maxWood)
        {
            woodCount++;
            GameObject.Instantiate(woodModel, woodPileSpawns[woodCount - 1].position, woodPileSpawns[woodCount - 1].rotation);
        }
    }

    public void OnMouseDown()
    {
        RemoveWood();
        
    }
}
