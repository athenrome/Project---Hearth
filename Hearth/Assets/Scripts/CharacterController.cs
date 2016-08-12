﻿using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public DialogueWindow diagWin; // where character dialogue is presented

    Director director;

    public Character character;

    CharacterOrders currOrder;
    CharacterOrders lastOrder;
    public float timeSinceLastAction;

    Waypoint waypointTarget;

    bool moving = false;

    public float moveSpeed;
    float startTime;
    float journeyLength;
    bool reachedDest;


    // Use this for initialization
    void Start () {
        timeSinceLastAction = Random.Range(0, 100);//mix up who goes first to prevent the same person from always talking first

        //currOrder = CharacterOrders.Idle;
        //Speak(DialogueType.NeedWoodPrompt);//TESTING
        director = FindObjectOfType<Director>();



    }
	
	// Update is called once per frame
	void Update () {

        timeSinceLastAction += Time.deltaTime;//increase character idle time

        //if (moving == true)
        //{

        //    float distCovered = (Time.time - startTime) * moveSpeed;
        //    float fracJourney = distCovered / journeyLength;
        //    transform.position = Vector3.Lerp(this.transform.position, waypointTarget.transform.position, fracJourney);
        //}

        //if (moving == true && NearLocation(waypointTarget) == true)//have i reached the target
        //{

        //    reachedDest = true;

        //    waypointTarget.locked = true;
        //    currOrder = CharacterOrders.Idle;
        //    ArriveAtPoint();
        //}








        if (diagWin.finished == true)
        {
            director.canSpeak = true;
            diagWin.finished = false;
        }


    }

    //void StartMove()
    //{
    //    Debug.Log("Starting Movment");

    //    startTime = Time.time;
    //    journeyLength = Vector3.Distance(this.transform.position, waypointTarget.transform.position);


    //    moving = true;
    //    reachedDest = false;
    //    waypointTarget.locked = true;
    //}

    public void ReceiveOrder(CharacterOrders _order)
    {
        switch(_order)
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

            default:
                Debug.Log("Invalid order");
                break;

                
        }
        
    }

    //public void MoveToPoint(Waypoint _point)
    //{
    //    waypointTarget = _point;
    //    Debug.Log("Move to Point");
    //    StartMove();

        
    //}

    //public void ArriveAtPoint()
    //{
        //reachedDest = true;

        //if(NearLocation(waypointTarget) == true && currOrder == CharacterOrders.GetWood == true)
        //{
        //    Debug.Log("Character entred forest");

        //    director.activeCharacters.Remove(this);

        //    director.forestCharacters.Add(this.character);

        //    GameObject.Destroy(this.gameObject);

        //}

        //if(NearLocation(director.woodPilePoint) && character.carryWood > 0)
        //{
        //    if(character.carryWood > 0)
        //    {
        //        Debug.Log("Place Wood");
        //        director.woodPile.AddWood(character.carryWood);
        //        character.carryWood = 0;

        //        //return back to starting pos

            
        //    }
        //}
    //}

    //bool NearLocation(Waypoint targetPoint)
    //{
    //    bool result = false;

    //    float acceptableDrift = 0.5f;//error distance

    //    if(Vector3.Distance(this.transform.position, targetPoint.transform.position) <= acceptableDrift || Vector3.Distance(this.transform.position, targetPoint.transform.position) <= acceptableDrift)
    //    {
    //        //Debug.Log("At Point");
    //        result = true;
    //    }

    //    return result;
    //}

    public void Speak(DialogueType toSpeak, bool forceSpeak)
    {

        if (director.canSpeak == true || forceSpeak == true)//if none else is speaking
        {
            Debug.Log("Start Speaking");
            director.canSpeak = false;

           

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

    RequestWood,
    InForest,
    GetWood,
    WoodToPile,




    NeedWoodPrompt,
    WoodArrivesPrompt,
    LightDropPrompt,
    LightBoostPrompt,
    DarknessPrompt,

    PositiveReaction,
    NegativeReation,

    MissionStart,
    MissionFail,
    MissionSuceed,

    HopefulStory,
    GhostStory,
}
