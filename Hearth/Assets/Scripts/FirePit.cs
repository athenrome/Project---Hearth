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
    }

    public void RemoveWood(Wood toRemove)
    {
        woodInFire.Remove(toRemove);
    }

}
