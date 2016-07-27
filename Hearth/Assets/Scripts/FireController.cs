using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

    public float minLightLevel;
    public float maxLightLevel;

    

    [Range(0f, 10f)]
    public float fireIntensity;

    public Light lightSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        lightSource.range += Time.deltaTime * 10;
        lightSource.intensity += Time.deltaTime;

    }

    void FlickerFlame()
    {

    }

    void AddFuel()
    {

    }

    void ConsumeFuel()
    {

    }
}

