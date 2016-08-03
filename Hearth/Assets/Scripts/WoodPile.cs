using UnityEngine;
using System.Collections;

public class WoodPile : MonoBehaviour {

    public int woodCount;

    public GameObject woodPrefab;

    public Transform woodSpawn;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        if(woodCount >= 1 )
        {
            GameObject.Instantiate(woodPrefab, woodSpawn.position, woodSpawn.rotation);
            woodCount--;
            Debug.Log("Spawn Log");
        }
        
    }
}
