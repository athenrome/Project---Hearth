using UnityEngine;
using System.Collections.Generic;

public class Flame : MonoBehaviour {

    public float minLevel = 5;
    public float maxLevel = 100;

    public Light lightSource;
    
    public float adjustmentRate; //rate at which flame will change each flame

    [Range(0f, 100f)]
    public float intensity; //flame intesity target

    float currIntensity; //value used to steadily scale flame intesnity

    bool actionInProgress;
    FlameAction currAction;

	// Use this for initialization
	void Start () {
        lightSource.range = minLevel;
	
	}
	
	// Update is called once per frame
	void Update () {

        adjustmentRate = Time.deltaTime;

        if (currIntensity < intensity)
        {
            lightSource.range += adjustmentRate;
        }

        if (currIntensity > intensity)
        {
            lightSource.range -= adjustmentRate;
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

