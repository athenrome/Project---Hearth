using UnityEngine;
using System.Collections.Generic;

public class WoodPile : MonoBehaviour {

    public int woodCount;
    int maxWood;

    public List<Transform> woodPileSpawns;

    public GameObject woodModel;//used to show wood amount in pile doesnt not have script attached
    public GameObject woodPrefab;//used to spawn dragable wood

    public Transform woodSpawn;

    List<GameObject> pileLogs = new List<GameObject>();




    bool pileChanged = false;

	// Use this for initialization
	void Start () {
        maxWood = woodPileSpawns.Count;

        AddWood(6);


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
                GameObject woodObj = GameObject.Instantiate(woodPrefab, woodPileSpawns[i].position, woodPileSpawns[i].rotation) as GameObject;
                pileLogs.Add(woodObj);
            }

            pileChanged = false;
        }
	
	}

    public void RemoveWood()
    {
        if (woodCount >= 1)
        {
            GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation);
            woodCount--;
            pileChanged = true;
            //Debug.Log("Spawn Log");
        }
    }

    public void AddWood(int toAdd)
    {
        for(int i = 0; i < toAdd; i++)
        {
            if (woodCount < maxWood)
            {
                woodCount++;
                pileChanged = true;

            }
        }
    }

    public void OnMouseDown()
    {
        RemoveWood();
        
    }
}
