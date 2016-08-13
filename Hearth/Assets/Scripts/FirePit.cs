using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Hack_Flame centralFlame;

    //public List<Wood> woodInFire;

    //public int fireSize;

    Director dir;

    // Use this for initialization
    void Start ()
    {
        dir = FindObjectOfType<Director>();
        //fireSize = 1;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //fireSize = Mathf.RoundToInt(centralFlame.intensity);

        UpdateFire();
        
	}

    public void AddWood(Wood toAdd)
    {

        Debug.Log("Fuel Fire");
        dir.woodPile.woodCount--;
        //dir.UpdateWorldState(WorldState.LightUp, false);
        centralFlame.StokeFire();

        //fireSize++;
        
    }

    public void RemoveWood()
    {
        //woodInFire.Remove(woodInFire[0]);//remove the oldest piece of wood in the fire
        //centralFlame.intensity -= adjustmentAmount;

        //Debug.Log("Wood Consumed");
        //fireSize--;       
    }

    void UpdateFire()
    {
        
    }

    void UpdateFog()
    {
        RenderSettings.fogDensity = 1F;
        RenderSettings.fog = true;
    }

}
