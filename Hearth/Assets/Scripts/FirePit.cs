using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Flame centralFlame;
    public List<Wood> woodInFire;

    public int fireSize;

    public float adjustmentAmount;//how much the fire increases per unit of wood

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fireSize = Mathf.RoundToInt(centralFlame.intensity);

        UpdateFire();
        
	}

    public void AddWood(Wood toAdd)
    {
        woodInFire.Add(toAdd);
        centralFlame.intensity += 5;

        Debug.Log("Fuel Fire");

        fireSize++;
    }

    public void RemoveWood()
    {
        woodInFire.Remove(woodInFire[0]);
        Debug.Log("Wood Consumed");
        fireSize--;       
    }

    void UpdateFire()
    {
        foreach (Wood fireWood in woodInFire)
        {
            fireWood.BurnWood();
        }
    }

}
