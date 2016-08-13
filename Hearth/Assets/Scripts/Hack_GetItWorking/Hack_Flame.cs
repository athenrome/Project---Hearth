using UnityEngine;
using System.Collections.Generic;

public class Hack_Flame : MonoBehaviour {

    public float minLevel;
    public float maxLevel;
    public float FogminLevel = 0.01f;
    public float FogmaxLevel = 0.12f;

    public Light lightSource;

    public ParticleSystem fireParticles;
    
    [Range(0f, 8f)]
    public float intensity; //flame intensity target

    public float logBurnTime = 0;
    public float maxBurnTime = 5;
    bool logActive = false;

    [FMODUnity.EventRef]
    public string fireSound = "event:/Fire/Fire";
    FMOD.Studio.EventInstance fireStartEvent;
    FMOD.Studio.ParameterInstance fire2;
    FMOD.Studio.ParameterInstance fire3;
    FMOD.Studio.ParameterInstance fire4;
    FMOD.Studio.ParameterInstance Embers;

    //bool actionInProgress;
    //FlameAction currAction;

    // Use this for initialization
    void Start ()
    {
        //lightSource.range = minLevel;

        //testing intensity
        intensity = 8;
	
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
        if (logActive == false)
        {
            intensity -= (Time.deltaTime / 10);
        }

        if (logActive == true)
        {
            logBurnTime -= Time.deltaTime;
            intensity += (Time.deltaTime / 5);

            if(logBurnTime <= 0)
            {
                logActive = false;
            }


        }

        if (lightSource.intensity <= intensity)
        {
            lightSource.intensity += Time.deltaTime;
        }

        if (lightSource.intensity > intensity)
        {
            lightSource.intensity -= Time.deltaTime;
        }

        //clamp intensity so it doesnt go way out of range.
        Mathf.Clamp(intensity, 0.0f, 8.0f);
                                                            //Debug.Log("clamped");
    }

    public void StokeFire()
    {
            logActive = true;
            logBurnTime = maxBurnTime;

    }

    void fireSoundControl()
    {

    }

}
