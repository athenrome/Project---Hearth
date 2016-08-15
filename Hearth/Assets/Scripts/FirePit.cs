using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Hack_Flame centralFlame;

    public GameObject fireParticles;

    public GameObject yellowFlame1;
    public GameObject yellowFlame2;

    public float flameShiftInterval;
    float currShiftinterval;

    public float flameShiftDist;

    bool shiftAlternate = true;

    Director director;


    //public List<Wood> woodInFire;

    //public int fireSize;

    // Use this for initialization
    void Start ()
    {
        director = FindObjectOfType<Director>();
        //fireSize = 1;

    }
	
	// Update is called once per frame
	void Update ()
    {

 
	}

    public void AddWood(Wood toAdd)
    {

        Debug.Log("Fuel Fire");
        director.woodPile.woodCount--;
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

    void OnMouseDown()
    {
        if(director.fireBurning == false)
        {
            centralFlame.StokeFire();
            director.fireBurning = true;

            fireParticles.SetActive(true);
        }

    }

    void UpdateFog()
    {
        RenderSettings.fogDensity = 1F;
        RenderSettings.fog = true;
    }

}
