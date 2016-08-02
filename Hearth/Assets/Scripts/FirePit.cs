using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Flame centralFlame;
    public List<Wood> woodInFire;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}  

    public void AddWood(Wood toAdd)
    {
        woodInFire.Add(toAdd);
        centralFlame.intensity += 5;

        centralFlame.transform.position = new Vector3(centralFlame.transform.position.x, centralFlame.transform.position.y + 1, centralFlame.transform.position.z);
    }

    public void RemoveWood(Wood toRemove)
    {
        woodInFire.Remove(toRemove);
    }

}
