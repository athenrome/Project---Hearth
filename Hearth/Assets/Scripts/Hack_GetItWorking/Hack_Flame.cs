using UnityEngine;
using System.Collections.Generic;

public class Hack_Flame : MonoBehaviour {

    public static Hack_Flame inst;

    public float minLevel;
    public float maxLevel;
    public float FogminLevel = 0.01f;
    public float FogmaxLevel = 0.12f;

    public Light lightSource;

    public ParticleSystem fireParticles;

    public static readonly float MaxIntensity = 8;
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
    FMOD.Studio.ParameterInstance embers;

    //bool actionInProgress;
    //FlameAction currAction;

    void Awake()
    {
        if (inst != null)
            DestroyImmediate(gameObject);
        else
            inst = this;
    }

    // Use this for initialization
    void Start ()
    {
        fireStartEvent = FMODUnity.RuntimeManager.CreateInstance(fireSound);
        fireStartEvent.getParameter("Fire 2", out fire2);
        fireStartEvent.getParameter("Fire 3", out fire3);
        fireStartEvent.getParameter("Fire 4", out fire4);
        fireStartEvent.getParameter("Embers", out embers); // actually is the torches being lit sound with an 18 second fadeout.
        fireStartEvent.start();

        //testing intensity
        intensity = minLevel;
        StokeFire();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(intensity);
        IntensityModifier();
        fireSoundControl();

    }

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

        if (lightSource.intensity <= intensity || lightSource.intensity < minLevel)
        {
            lightSource.intensity += Time.deltaTime;
        }

        if (lightSource.intensity > intensity)
        {
            lightSource.intensity -= Time.deltaTime;
        }

        //clamp intensity so it doesnt go way out of range.
        Mathf.Clamp(intensity, minLevel, maxLevel);

        if(intensity < minLevel)
        {
            intensity = minLevel;
        }

                                                            //Debug.Log("clamped");
    }

    public void StokeFire()
    {
            logActive = true;
            logBurnTime = maxBurnTime;

    }

    void fireSoundControl()
    {
        if(intensity > 1 && intensity < 3)
        {
            fire2.setValue(1);
            fire3.setValue(0);
            fire4.setValue(0);

            //Debug.Log("Fire 2 active");
        }

        if (intensity > 3 && intensity < 5)
        {
            fire2.setValue(1);
            fire3.setValue(1);
            fire4.setValue(0);

            //Debug.Log("Fire 3 active");
        }

        if (intensity > 5)
        {
            fire2.setValue(1);
            fire3.setValue(1);
            fire4.setValue(1);

            //Debug.Log("Fire is at max");
        }

        if (intensity > 100 /* Set this once we know the final requirements to finish the game. */)
        {
            //probably wont get used until we can make people walk away. #Embers
        }
    }

    
}
