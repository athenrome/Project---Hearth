using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour {

    public PlayerVisibilityController visCon;
    public CharacterController charCon;
    public float Hopetimer = 0;
    private float hopeCounter = 0;
    public bool hasFiredHope = false;

    public bool enableGenericDialog = false;
    public float genericMin, genericMax, curGenericTimer, genCounter;

    public Director dir;

    void Awake()
    {
        dir = FindObjectOfType<Director>();
    }

	void OnEnable()
    {
        hasFiredHope = false;
        RollGenericTimer();
    }

    void RollGenericTimer()
    {
        curGenericTimer = Random.Range(genericMin, genericMax);
        genCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if(!dir.actionInProgress)
        { 
         if (visCon.desiredVisibility > 0)
         {
             if (!hasFiredHope)
             {
                 hopeCounter += Time.deltaTime;
                 if (hopeCounter > Hopetimer)
                 {
                     charCon.Speak(DialogueType.HopefulStory, false);
                     hasFiredHope = true;
                     RollGenericTimer();
                 }
             }
             else { hopeCounter = 0; }

             if (enableGenericDialog)
             {
                 genCounter += Time.deltaTime;

                 if (genCounter > curGenericTimer)
                 {
                     charCon.Speak(DialogueType.LightDropPrompt, false);
                     RollGenericTimer();
                 }
             }
         }
        }
	}
}
