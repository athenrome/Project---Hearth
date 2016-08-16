using UnityEngine;
using System.Collections;

public class DialougeTest : MonoBehaviour {

    public CharacterController charCont;
    public CharacterOrders charOrd;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialouge();
        }
	}

    void TriggerDialouge()
    {
        Director.inst.OrderCharacter(charCont, charOrd);
    }
}
