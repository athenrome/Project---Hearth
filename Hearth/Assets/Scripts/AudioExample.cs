using UnityEngine;
using System.Collections;

public class AudioExample : MonoBehaviour {

    [FMODUnity.EventRef]
    public string atmoSound = "event:/Atmos/Atmos";
    FMOD.Studio.EventInstance AtmoStartEvent;

	// Use this for initialization
	void Start ()
    {
        //FMODUnity.RuntimeManager.PlayOneShot(atmoSound);
        AtmoStartEvent = FMODUnity.RuntimeManager.CreateInstance(atmoSound);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

}
