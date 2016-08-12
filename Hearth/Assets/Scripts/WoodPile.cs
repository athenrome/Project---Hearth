using UnityEngine;
using System.Collections.Generic;

public class WoodPile : MonoBehaviour {

    public int woodCount;
    public int maxWood;

    //public List<Transform> woodPileSpawns;

    //public GameObject woodModel;//used to show wood amount in pile doesnt not have script attached
    public GameObject woodPrefab;//used to spawn dragable wood

    public Transform woodSpawn;

    List<GameObject> pileLogs = new List<GameObject>();

    public Director dir;

    public float woodSpawnTimeout;
    float currTimeout;

    

    public int woodToAdd;
    bool pileChanged = false;

	// Use this for initialization
	void Start () {

        woodCount = 0;

        AddWood(6);
    }
	
	// Update is called once per frame
	void Update () {

        if (woodToAdd > 0)
        {
            if (currTimeout <= 0)
            {
                SpawnPileLog();
                currTimeout = woodSpawnTimeout;
            }
            else
            {
                currTimeout -= Time.deltaTime;
            }
        }


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
        if(woodCount + toAdd >= maxWood)
        {
            toAdd = maxWood - woodCount;
        }

        woodToAdd = toAdd;


    }

    void SpawnPileLog()
    {
        GameObject woodObj = GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation) as GameObject;
        pileLogs.Add(woodObj);
        woodCount++;
        woodToAdd--;
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Wood>() == true)
    //    {
    //        woodCount++;

    //        Debug.Log("added Log");
    //    }
    //}

    //public void OnTriggerEnter(Collider enterObj)
    //{
    //    if (enterObj.GetComponent<Wood>() == true)
    //    {
    //        pileLogs.Add(enterObj.gameObject);
    //        woodCount++;

    //        Debug.Log("added Log");
    //    }
    //}

    //public void OnTriggerExit(Collider exitObj)
    //{
    //    if (exitObj.GetComponent<Wood>() == true)
    //    {
    //        pileLogs.Remove(exitObj.gameObject);
    //        RemoveWood();

    //        Debug.Log("Removed Log");
    //    }
    //}

    //public void OnMouseDown()
    //{
    //    RemoveWood();
        
    //}
}
