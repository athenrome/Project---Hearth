using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

    public PlayerVisibilityController visCon;
    public CharacterController charCon;
    public float timer = 0;
    private float counter = 0;
    public bool hasFiredHope = false;

	void OnEnable()
    {
        hasFiredHope = false;
    }
	
	// Update is called once per frame
	void Update () {
	
        if(visCon.desiredVisibility > 0 && !hasFiredHope)
        {
            counter += Time.deltaTime;
            if (counter > timer)
            {
                charCon.Speak(DialogueType.HopefulStory,false);
                hasFiredHope = true;
            }
        }
        else { counter = 0; }
	}
}
