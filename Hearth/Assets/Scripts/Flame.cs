using UnityEngine;
using System.Collections.Generic;

public class Flame : MonoBehaviour {

    public float minLevel;
    public float maxLevel;

    public Light lightSource;

    public ParticleSystem fireParticles;
    
    [Range(0f, 100f)]
    public float intensity; //flame intesity target

    

    bool actionInProgress;
    FlameAction currAction;

	// Use this for initialization
	void Start () {
        lightSource.range = minLevel;
	
	}
	
	// Update is called once per frame
	void Update () {

        

        if (lightSource.range <= intensity)
        {
            lightSource.range += Time.deltaTime;
        }

        if (lightSource.range >= intensity)
        {
            lightSource.range -= Time.deltaTime;
        }


    }



}

public enum FlameAction
{
    BurnUp,
    BurnDown,
    Flicker,
    StartBurn,
    EndBurn,

}

