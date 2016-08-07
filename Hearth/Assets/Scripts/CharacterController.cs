using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public DialogueWindow diagWin; // where character dialogue is presented



    public Character character;

    CharacterActions currAction;
    CharacterActions lastAction;
    float timeSinceLastAction;

    Waypoint target;
    Waypoint startPoint;

    public float moveSpeed = 1f;
    float startTime;
    float journeyLength;
    bool reachedDest;


    // Use this for initialization
    void Start () {
        //currAction = CharacterActions.Idle;
        //Speak(DialogueType.NeedWoodPrompt);//TESTING
	
	}
	
	// Update is called once per frame
	void Update () {
       

        if (currAction == CharacterActions.StartMove)
        {
            Debug.Log("Starting Movment");
            startPoint.occupied = false;

            startTime = Time.time;
            journeyLength = Vector3.Distance(startPoint.transform.position, target.transform.position);

            
            currAction = CharacterActions.Move;
            reachedDest = false;
        }
        
        
        if(currAction == CharacterActions.Move && reachedDest == false && this.transform.position == target.pos)//have i reached the target
        {
            Debug.Log("Idling");
            target.occupied = true;
            currAction = CharacterActions.Idle;
            ArriveAtPoint();
        }



        if (currAction == CharacterActions.Move)
        {
            target.occupied = false;
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint.transform.position, target.transform.position, fracJourney);
        }

        if(currAction == CharacterActions.Idle)
        {
            timeSinceLastAction += Time.deltaTime;
        }


    }

    public void MoveToPoint(Waypoint _point, Waypoint _startPoint)
    {
        target = _point;
        startPoint = _startPoint;
        currAction = CharacterActions.StartMove;

    }

    public void ArriveAtPoint()
    {
        Speak(DialogueType.NeedWoodPrompt);
        reachedDest = true;
    }

    public void Speak(DialogueType toSpeak)
    {
        currAction = CharacterActions.Speak;

        Dialogue targetDialogue = character.ChooseDialogue(toSpeak);



        diagWin.WriteDialogue(targetDialogue);
    }
}

public enum CharacterActions
{
    Idle,
    Speak,
    StartMove,
    Move,
    InForest,
}
