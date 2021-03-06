﻿using UnityEngine;
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

        if(diagWin.finished == true && director.actionInProgress == true)
        {
            director.actionInProgress = false;
        }

    }
    
    public void ReceiveOrder(CharacterOrders _order)
    {

        if(director.actionInProgress == false)
        {
            switch (_order)
            {
                case CharacterOrders.RequestWood:

                    Speak(DialogueType.NeedWoodPrompt, true);
                    //Debug.Log("wood order recieved");
                    break;

                case CharacterOrders.SpeakHope:
                    Speak(DialogueType.HopefulStory, true);
                    break;

                case CharacterOrders.SpeakGhost:
                    Speak(DialogueType.GhostStory, true);
                    break;

                case CharacterOrders.SpeakLightUp:
                    Speak(DialogueType.LightBoostPrompt, true);
                    break;

                case CharacterOrders.SpeakLightDrop:
                    Speak(DialogueType.LightDropPrompt, true);
                    break;



                default:
                    Debug.Log("Invalid order");
                    break;


            }
        }

        
        
    }

    

    public void Speak(DialogueType toSpeak, bool forceSpeak)
    {
        if (!isActiveAndEnabled || director.actionInProgress == true)//!diagWin.finished)
            return;

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
        }
        else
        {
            Debug.Log("Speaking blocked");
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
