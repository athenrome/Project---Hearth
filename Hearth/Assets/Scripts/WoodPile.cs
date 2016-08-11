using UnityEngine;
using System.Collections.Generic;

public class WoodPile : MonoBehaviour {

    public int woodCount;
    int maxWood;

    public List<Transform> woodPileSpawns;

    //public GameObject woodModel;//used to show wood amount in pile doesnt not have script attached
    public GameObject woodPrefab;//used to spawn dragable wood

    public Transform woodSpawn;

    List<GameObject> pileLogs = new List<GameObject>();




    bool pileChanged = false;

	// Use this for initialization
	void Start () {
        //maxWood = woodPileSpawns.Count;

        //woodCount = 0;

        //AddWood(6);

        //SetWoodPositions();

    }
	
	// Update is called once per frame
	void Update () {

	}

    public void RemoveWood()
    {
        if (woodCount >= 1)
        {
            //GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation);
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

                GameObject woodObj = GameObject.Instantiate(woodPrefab, woodPileSpawns[i].position, woodPileSpawns[i].rotation) as GameObject;
                pileLogs.Add(woodObj);

                woodObj.transform.position = woodPileSpawns[woodCount].transform.position;
                woodObj.transform.rotation = woodPileSpawns[woodCount].transform.rotation;

            }
        }
    }

    void SetWoodPositions()
    {
        for(int i = 0; i < pileLogs.Count; i++)
        {
            pileLogs[i].transform.position = woodPileSpawns[i].transform.position;
            pileLogs[i].transform.rotation = woodPileSpawns[i].transform.rotation;
        }
    }

    public void OnTriggerEnter(Collider enterObj)
    {
        if(enterObj.GetComponent<Wood>() == true)
        {
            pileLogs.Add(enterObj.gameObject);
            SetWoodPositions();

            Debug.Log("added Log");
        }
    }

    public void OnTriggerExit(Collider exitObj)
    {
        if (exitObj.GetComponent<Wood>() == true)
        {
            pileLogs.Remove(exitObj.gameObject);
            SetWoodPositions();

            Debug.Log("Removed Log");
        }
    }

    public void OnMouseDown()
    {
        RemoveWood();
        
    }
}
