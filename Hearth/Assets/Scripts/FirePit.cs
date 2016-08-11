using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Flame centralFlame;
    public List<Wood> woodInFire;

    public int fireSize;

    public float adjustmentAmount;//how much the fire increases per unit of wood
    public float fogadjustmentAmount;//how much the fog decreases per unit of wood added to the fire

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        fireSize = Mathf.RoundToInt(centralFlame.intensity);

        UpdateFire();
        
	}

    public void AddWood(Wood toAdd)
    {
        woodInFire.Add(toAdd);
        centralFlame.intensity += adjustmentAmount;

        Debug.Log("Fuel Fire");

        fireSize++;
    }

    public void RemoveWood()
    {
        woodInFire.Remove(woodInFire[0]);
        centralFlame.intensity -= adjustmentAmount;

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

    void UpdateFog()
    {
        RenderSettings.fogDensity = 1F;
        RenderSettings.fog = true;
    }

}
