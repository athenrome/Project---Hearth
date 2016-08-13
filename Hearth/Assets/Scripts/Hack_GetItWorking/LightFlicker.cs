using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    public AnimationCurve flickerCurve = AnimationCurve.Linear(0,1,1,1);
    public float counter, rate = 1;
    private Light myLight;
    //private float prevFlickerAmount;
    //public float flickerPercentage = 0.1f;
    public float targetIntensity = 1;

    //the value used to offset one flames brightness from another. this should be set to 0 on one, and # on the other flame in the inspector.
    public float offset;


    //restore this after fixing the hack... should use flame instead of hack flame
    //public Flame flame;
    
    //Hacking>>>>>>>>>>>>>>>>
    public Hack_Flame flame;

    //Hacking End>>>>>>>>>>>>>



    // Use this for initialization
    void Start ()
    {
        //restore this after fixing the hack... should use flame instead of hack flame
        //flame = FindObjectOfType<Flame>();
        flame = FindObjectOfType<Hack_Flame>();
        myLight = GetComponent<Light>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        targetIntensity = flame.intensity - offset;

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
