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


    public float moveSpeed = 1f;
    float startTime;
    float journeyLength;
    bool reachedDest;


    // Use this for initialization
    void Start () {
        //currAction = CharacterActions.Idle;
        //Speak(DialogueType.NeedWoodPrompt);//TESTING
        director = FindObjectOfType<Director>();

    }
	
	// Update is called once per frame
	void Update () {
       

        if (currOrder == CharacterOrders.StartMove)
        {
            Debug.Log("Starting Movment");

            startTime = Time.time;
            journeyLength = Vector3.Distance(this.transform.position, waypointTarget.transform.position);


            currOrder = CharacterOrders.Move;
            reachedDest = false;
            waypointTarget.locked = true;
        }

        if (currOrder == CharacterOrders.Move)
        {
            
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(this.transform.position, waypointTarget.transform.position, fracJourney);
        }

        if (currOrder == CharacterOrders.Move && NearLocation(waypointTarget) == true)//have i reached the target
        {

            reachedDest = true;

            waypointTarget.locked = true;
            currOrder = CharacterOrders.Idle;
            ArriveAtPoint();
        }



       

        if(currOrder == CharacterOrders.Idle)
        {
            timeSinceLastAction += Time.deltaTime;
        }


    }

    public void ReceiveOrder(CharacterOrders _order)
    {
        switch(_order)
        {
            case CharacterOrders.GetWood:
                waypointTarget = director.forestPoint;
                currOrder = CharacterOrders.StartMove;
                Debug.Log("Get Wood");

                break;

                
        }
        
    }

    public void MoveToPoint(Waypoint _point)
    {
        waypointTarget = _point;

        currOrder = CharacterOrders.StartMove;

        
    }

    public void ArriveAtPoint()
    {
        //Testing     Speak(DialogueType.GhostStory);
        reachedDest = true;



        if(NearLocation(director.forestPoint) == true)
        {
            Debug.Log("Character entred forest");

            Debug.Log(director.activeCharacters.Count);
            director.activeCharacters.Remove(this);
            Debug.Log(director.activeCharacters.Count);

            director.forestCharacters.Add(this.character);

            GameObject.Destroy(this.gameObject);

        }

        if(NearLocation(director.woodPilePoint))
        {
            if(director.woodOrdered == true)
            {
                Debug.Log("Place Wood");
                director.woodPile.AddWood(character.carryWood);
                director.woodOrdered = false;
                
            }
        }
    }

    bool NearLocation(Waypoint targetPoint)
    {
        bool result = false;

        float acceptableDrift = 0.5f;//error distance

        if(Vector3.Distance(this.transform.position, targetPoint.transform.position) <= acceptableDrift || Vector3.Distance(this.transform.position, targetPoint.transform.position) <= acceptableDrift)
        {
            Debug.Log("At Point");
            result = true;
        }

        return result;
    }

    public void Speak(DialogueType toSpeak)
    {
        if(director.canTalk == true)
        {
            currOrder = CharacterOrders.Speak;

            if (toSpeak == DialogueType.HopefulStory || toSpeak == DialogueType.GhostStory)
            {
                DialogueStory targetStory = character.ChooseStory(toSpeak);
                diagWin.WriteStory(targetStory);
            }
            else
            {
                Dialogue targetDialogue = character.ChooseDialogue(toSpeak);
                diagWin.WriteDialogue(targetDialogue);
            }

            director.canTalk = false;
        }
        else
        {
            Debug.Log("Talking blocked");
        }






    }
}

public enum CharacterOrders
{
    Idle,
    Speak,
    StartMove,
    Move,

    InForest,
    GetWood,
    WoodToPile,    
}
