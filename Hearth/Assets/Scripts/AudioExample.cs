using UnityEngine;
using System.Collections;

public class AudioExample : MonoBehaviour {

    [FMODUnity.EventRef]
    public string atmoSound = "event:/Atmos/Atmos";

    [FMODUnity.EventRef]
    public string textTypeSound = "event:/Player/Speech_Bubble";
    FMOD.Studio.EventInstance TalkStartEvent;

    [FMODUnity.EventRef]
    public string fireSound = "event:/Fire/Fire";
    FMOD.Studio.EventInstance fireStartEvent;
    FMOD.Studio.ParameterInstance fire2;
    FMOD.Studio.ParameterInstance fire3;
    FMOD.Studio.ParameterInstance fire4;
    FMOD.Studio.ParameterInstance Embers;

    // Use this for initialization
    void Start ()
    {
        FMODUnity.RuntimeManager.PlayOneShot(atmoSound);
        TalkStartEvent = FMODUnity.RuntimeManager.CreateInstance(textTypeSound);

    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

}
