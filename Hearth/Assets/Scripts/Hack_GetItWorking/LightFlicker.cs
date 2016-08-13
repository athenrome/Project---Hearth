using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    public AnimationCurve flickerCurve = AnimationCurve.Linear(0,1,1,1);
    public float counter, rate = 1;
    private Light myLight;
    //private float prevFlickerAmount;
    //public float flickerPercentage = 0.1f;
    public float targetIntensity = 1;
    public Flame flame;


	// Use this for initialization
	void Start ()
    {
        flame = FindObjectOfType<Flame>();
        myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //targetIntensity = flame.intensity;

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
