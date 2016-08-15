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

    //used to move the light around light it is flickering
    public Vector3 oscillateScale;
    public Vector3 oscillateOffset;

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
        moveFlame();

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

    void moveFlame()
    {
        transform.localPosition = new Vector3((Mathf.PerlinNoise(Time.realtimeSinceStartup * oscillateScale.x, 10) - 0.5f) * oscillateOffset.x,
        (Mathf.PerlinNoise(Time.realtimeSinceStartup * oscillateScale.y, 20) - 0.5f) * oscillateOffset.y,
        (Mathf.PerlinNoise(Time.realtimeSinceStartup * oscillateScale.z, 30) - 0.5f) * oscillateOffset.z);
    }

}
