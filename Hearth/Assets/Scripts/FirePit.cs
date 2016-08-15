using UnityEngine;
using System.Collections.Generic;

public class FirePit : MonoBehaviour {

    public Hack_Flame centralFlame;

    public GameObject yellowFlame1;
    public GameObject yellowFlame2;

    public float flameShiftInterval;
    float currShiftinterval;

    public float flameShiftDist;

    bool shiftAlternate = true;

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

        if (currShiftinterval <= 0)
        {

            if (shiftAlternate == true)
            {
                Debug.Log(yellowFlame1.transform.localPosition.x);
                yellowFlame1.transform.localPosition = new Vector3(yellowFlame1.transform.localPosition.x + flameShiftDist, yellowFlame1.transform.localPosition.y, yellowFlame1.transform.localPosition.z);
                yellowFlame2.transform.localPosition = new Vector3(yellowFlame1.transform.localPosition.x - flameShiftDist, yellowFlame1.transform.localPosition.y, yellowFlame1.transform.localPosition.z);
                shiftAlternate = false;
            }
            else
            {
                yellowFlame1.transform.position = new Vector3(yellowFlame1.transform.position.x - flameShiftDist, yellowFlame1.transform.position.y, yellowFlame1.transform.position.z);
                yellowFlame2.transform.position = new Vector3(yellowFlame1.transform.position.x + flameShiftDist, yellowFlame1.transform.position.y, yellowFlame1.transform.position.z);
                shiftAlternate = true;
            }

            currShiftinterval = flameShiftInterval;

        }
        else
        {
            currShiftinterval -= Time.deltaTime;
        }

        
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
