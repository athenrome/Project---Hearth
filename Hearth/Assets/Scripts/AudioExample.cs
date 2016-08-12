using UnityEngine;
using System.Collections;

public class AudioExample : MonoBehaviour {

    [FMODUnity.EventRef]
    public string atmoSound = "event:/Atmos/Atmos";
    public string textTypeSound = "event:/Player/Speech_Bubble";
    FMOD.Studio.EventInstance TalkStartEvent;



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
