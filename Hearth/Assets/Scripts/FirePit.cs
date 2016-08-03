using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Flame centralFlame;
    public List<Wood> woodInFire;

    public int fireSize;

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

        fireSize++;
    }

    public void RemoveWood(Wood toRemove)
    {
        woodInFire.Remove(toRemove);
        fireSize--;       
    }

    void UpdateFire()
    {
        float targetIntensity = woodInFire.Count * 5;

        centralFlame.intensity = targetIntensity;
    }

}
