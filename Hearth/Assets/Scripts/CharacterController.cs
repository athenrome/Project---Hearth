using UnityEngine;
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
        //currOrder = CharacterOrders.Idle;
        //Speak(DialogueType.NeedWoodPrompt);//TESTING
        director = FindObjectOfType<Director>();

        Speak(DialogueType.MissionStart);

    }
	
	// Update is called once per frame
	void Update () {

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



       

        //if(currOrder == CharacterOrders.Idle)
        //{
        //    timeSinceLastAction += Time.deltaTime;
        //}

        if(diagWin.finished == true)
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
                
                Speak(DialogueType.NeedWoodPrompt);
                Debug.Log("wood order recieved");
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

    public void Speak(DialogueType toSpeak)
    {



        if (director.canSpeak == true)//if none else is speaking
        {
            Debug.Log("Start Speaking");
            director.canSpeak = false;

            

            if (toSpeak == DialogueType.HopefulStory || toSpeak == DialogueType.GhostStory)
            {
                DialogueStory targetStory = character.ChooseStory(toSpeak);
                diagWin.WriteStory(targetStory);

                currOrder = CharacterOrders.Speak;
            }
            else
            {
                
                Dialogue targetDialogue = character.ChooseDialogue(toSpeak);
                diagWin.WriteDialogue(targetDialogue);

                currOrder = CharacterOrders.Speak;
                
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
    Speak,
    //StartMove,
    //Move,

    RequestWood,
    InForest,
    GetWood,
    WoodToPile,    
}
