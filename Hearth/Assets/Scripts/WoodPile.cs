using UnityEngine;
using System.Collections.Generic;

public class WoodPile : MonoBehaviour {

    public int woodCount = 0;
    public int maxWood = 5;

    public List<Transform> woodPileSpawns;

    public GameObject woodModel;//used to show wood amount in pile doesnt not have script attached
    public GameObject woodPrefab;//used to spawn dragable wood

    public Transform woodSpawn;

    List<GameObject> pileLogs = new List<GameObject>();


    bool pileChanged = false;

	// Use this for initialization
	void Start () {
        AddWood();
        AddWood();
        AddWood();
        AddWood();
        AddWood();
        AddWood();

        pileChanged = true;

    }
	
	// Update is called once per frame
	void Update () {

       
        

        if(pileChanged == true)
        {
            if (pileLogs.Count > 0)//clear all spawned logs
            {
                foreach (GameObject obj in pileLogs)
                {
                    GameObject.Destroy(obj);
                }
            }

            for (int i = 0; i < woodCount; i++)//spawn new logs
            {
                GameObject woodObj = GameObject.Instantiate(woodModel, woodPileSpawns[i].position, woodPileSpawns[i].rotation) as GameObject;
                pileLogs.Add(woodObj);
            }

            pileChanged = false;
        }
	
	}

    void RemoveWood()
    {
        if (woodCount >= 1)
        {
            GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation);
            woodCount--;
            pileChanged = true;
            //Debug.Log("Spawn Log");
        }
    }

    void AddWood()
    {
        if(woodCount < maxWood)
        {
            woodCount++;
            pileChanged = true;
            
        }
    }

    public void OnMouseDown()
    {
        RemoveWood();
        
    }
}
