using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    public AnimationCurve flickerCurve = AnimationCurve.Linear(0,1,1,1);
    public float counter, rate = 1;
    private Light myLight;
    //private float prevFlickerAmount;
    //public float flickerPercentage = 0.1f;
    public float targetIntensity = 1;
<<<<<<< HEAD:Hearth/Assets/Scripts/Hack_GetItWorking/LightFlicker.cs
    public Flame flame;
=======
>>>>>>> 05d2ecd3f8db77f4f77d4930db7b7e306bed1ce0:Hearth/Assets/Scripts/LightFlicker.cs


	// Use this for initialization
	void Start ()
    {
<<<<<<< HEAD:Hearth/Assets/Scripts/Hack_GetItWorking/LightFlicker.cs
        flame = FindObjectOfType<Flame>();
=======
>>>>>>> 05d2ecd3f8db77f4f77d4930db7b7e306bed1ce0:Hearth/Assets/Scripts/LightFlicker.cs
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
