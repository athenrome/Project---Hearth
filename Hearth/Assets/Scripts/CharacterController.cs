using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

   

    public DialogueWindow diagWin; // where character dialogue is presented

    public CharacterData characterData;

    Director director;

    public Character character;

    CharacterOrders currOrder;
    CharacterOrders lastOrder;
    public float timeSinceLastAction;


    // Use this for initialization
    void Start () {

        timeSinceLastAction = Random.Range(0, 100);//mix up who goes first to prevent the same person from always talking first
        director = FindObjectOfType<Director>();


        character = new Character(characterData);
    }
	
	// Update is called once per frame
	void Update () {

        timeSinceLastAction += Time.deltaTime;//increase character idle time

        if(diagWin.finished == false)
        {
            // director.actionInProgress |= true;
            director.canSpeak = false;
        }

    }
    
    public bool ReceiveOrder(CharacterOrders _order)
    {
        switch(_order)
        {
            case CharacterOrders.RequestWood:
                
                return Speak(DialogueType.NeedWoodPrompt, false);
                //Debug.Log("wood order recieved");
                break;

            case CharacterOrders.SpeakHope:
                return Speak(DialogueType.HopefulStory, false);
                break;

            case CharacterOrders.SpeakGhost:
                return Speak(DialogueType.GhostStory, false);
                break;

            case CharacterOrders.SpeakLightUp:
                return Speak(DialogueType.LightBoostPrompt, false);
                break;

            case CharacterOrders.SpeakLightDrop:
                return Speak(DialogueType.LightDropPrompt, false);
                break;



            default:
                Debug.Log("Invalid order");
                return true;
                break;

                
        }
        
    }

    

    public bool Speak(DialogueType toSpeak, bool forceSpeak)
    {
        if (!isActiveAndEnabled )//|| !diagWin.finished)
            return false;

        if (director.canSpeak == true || forceSpeak == true)//if none else is speaking
        {
            Debug.Log("Start Speaking");
            director.canSpeak = false;
            director.actionInProgress = true;

           

            if (toSpeak == DialogueType.HopefulStory || toSpeak == DialogueType.GhostStory)
            {
                DialogueStory targetStory = character.ChooseStory(toSpeak);
                diagWin.WriteStory(targetStory);
            }
            else
            {
                Dialogue targetDialogue = character.ChooseDialogue(toSpeak);
                diagWin.WriteDialogue(targetDialogue);


                currOrder = CharacterOrders.SpeakDialogue;
                
            }
            return true;
        }
        else
        {
            Debug.Log("Speaking blocked");
            return false;
        }

    }


}

public enum CharacterOrders
{
    Idle,

    SpeakDialogue,
    SpeakHope,
    SpeakGhost,

    
    //StartMove,
    //Move,

    SpeakLightUp,
    SpeakLightDrop,

    RequestWood,
    InForest,
    GetWood,
    WoodToPile,    
}
