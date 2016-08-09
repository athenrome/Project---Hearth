using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public DialogueWindow diagWin; // where character dialogue is presented

    Director director;

    public Character character;

    CharacterOrders currOrder;
    CharacterOrders lastOrder;
    public float timeSinceLastAction;

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
       

        if (currOrder == CharacterOrders.StartMove)
        {
            Debug.Log("Starting Movment");

            startTime = Time.time;
            journeyLength = Vector3.Distance(this.transform.position, target.transform.position);


            currOrder = CharacterOrders.Move;
            reachedDest = false;
        }
        
        
        if(currOrder == CharacterOrders.Move && reachedDest == false && this.transform.position == target.pos)//have i reached the target
        {

            target.locked = true;
            currOrder = CharacterOrders.Idle;
            ArriveAtPoint();
        }



        if (currOrder == CharacterOrders.Move)
        {
            target.locked = false;
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(this.transform.position, target.transform.position, fracJourney);
        }

        if(currOrder == CharacterOrders.Idle)
        {
            timeSinceLastAction += Time.deltaTime;
        }


    }

    public void ReceiveOrder(CharacterOrders order)
    {
        switch(order)
        {

        }
    }

    public void MoveToPoint(Waypoint _point)
    {
        target = _point;

        currOrder = CharacterOrders.StartMove;
    }

    public void ArriveAtPoint()
    {
        //Testing     Speak(DialogueType.GhostStory);
        reachedDest = true;
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
