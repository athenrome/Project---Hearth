﻿using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    public AnimationCurve flickerCurve = AnimationCurve.Linear(0,1,1,1);
    public float counter, rate = 1;
    private Light myLight;
    //private float prevFlickerAmount;
    //public float flickerPercentage = 0.1f;
    public float targetIntensity = 1;


	// Use this for initialization
	void Start ()
    {
        myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        counter += Time.deltaTime;
        if(counter > rate)
        {
            counter -= rate;
        }

        var currFlickerAmount = flickerCurve.Evaluate(counter / rate);

        myLight.intensity = currFlickerAmount * targetIntensity;
        //prevFlickerAmount = currFlickerAmount;

	}


}