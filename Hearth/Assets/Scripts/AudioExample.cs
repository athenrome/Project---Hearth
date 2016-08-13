using UnityEngine;
using System.Collections;

public class AudioExample : MonoBehaviour {

    [FMODUnity.EventRef]
    public string atmoSound = "event:/Atmos/Atmos";
    public string textTypeSound = "event:/Player/Speech_Bubble";
    public string fireSound = "event:/Fire/Fire";
    FMOD.Studio.EventInstance fireBurnSound;
    FMOD.Studio.ParameterInstance fireSizeSound;
    FMOD.Studio.EventInstance talkStartEvent;



	// Use this for initialization
	void Start ()
    {
        FMODUnity.RuntimeManager.PlayOneShot(atmoSound);
        fireBurnSound = FMODUnity.RuntimeManager.CreateInstance(fireSound);
        talkStartEvent = FMODUnity.RuntimeManager.CreateInstance(textTypeSound);

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

}
