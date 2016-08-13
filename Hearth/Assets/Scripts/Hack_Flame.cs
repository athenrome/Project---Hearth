using UnityEngine;
using System.Collections.Generic;

public class Hack_Flame : MonoBehaviour {

    public float minLevel;
    public float maxLevel;

    public Light lightSource;

    public ParticleSystem fireParticles;
    
    [Range(0f, 100f)]
    public float intensity; //flame intensity target

    

    bool actionInProgress;
    FlameAction currAction;

	// Use this for initialization
	void Start ()
    {
        //lightSource.range = minLevel;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        IntensityModifier();
        //RangeModifier();
    }

   /*
   void RangeModifier()
    {
        if (lightSource.range <= intensity)
        {
            lightSource.range += Time.deltaTime;
        }

        if (lightSource.range >= intensity)
        {
            lightSource.range -= Time.deltaTime;
        }
    }
    */
    void IntensityModifier()
    {
        if (lightSource.intensity < intensity)
        {
            lightSource.intensity += Time.deltaTime;
        }

        if (lightSource.intensity > intensity)
        {
            lightSource.intensity -= Time.deltaTime;
        }
    }

}
