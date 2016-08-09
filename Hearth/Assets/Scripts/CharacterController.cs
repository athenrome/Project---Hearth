using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public DialogueWindow diagWin; // where character dialogue is presented

    Director director;

    public Character character;

    CharacterActions currAction;
    CharacterActions lastAction;
    float timeSinceLastAction;

    Waypoint target;


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
       

        if (currAction == CharacterActions.StartMove)
        {
            Debug.Log("Starting Movment");

            startTime = Time.time;
            journeyLength = Vector3.Distance(this.transform.position, target.transform.position);

            
            currAction = CharacterActions.Move;
            reachedDest = false;
        }
        
        
        if(currAction == CharacterActions.Move && reachedDest == false && this.transform.position == target.pos)//have i reached the target
        {

            target.locked = true;
            currAction = CharacterActions.Idle;
            ArriveAtPoint();
        }



        if (currAction == CharacterActions.Move)
        {
            target.locked = false;
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(this.transform.position, target.transform.position, fracJourney);
        }

        if(currAction == CharacterActions.Idle)
        {
            timeSinceLastAction += Time.deltaTime;
        }


    }

    public void MoveToPoint(Waypoint _point)
    {
        target = _point;

        currAction = CharacterActions.StartMove;
    }

    public void ArriveAtPoint()
    {
        Speak(DialogueType.GhostStory);
        reachedDest = true;
    }

    public void Speak(DialogueType toSpeak)
    {
        if(director.canTalk == true)
        {
            currAction = CharacterActions.Speak;

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

public enum CharacterActions
{
    Idle,
    Speak,
    StartMove,
    Move,
    InForest,
}
