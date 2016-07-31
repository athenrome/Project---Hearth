using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public CharacterActions currAction;
    CharacterActions lastAction;

    public Waypoint target;
    public Waypoint startPoint;

    public float moveSpeed = 1f;
    private float startTime;
    private float journeyLength;


    // Use this for initialization
    void Start () {
        currAction = CharacterActions.StartMove;
	
	}
	
	// Update is called once per frame
	void Update () {

        if(currAction == CharacterActions.StartMove)
        {
            startTime = Time.time;
            journeyLength = Vector3.Distance(startPoint.transform.position, target.transform.position);

            //Debug.Log("Starting Movment");
            currAction = CharacterActions.Move;
        }
        
        
        if(this.transform.position == target.pos)//have i reached the target
        {
            //Debug.Log("Idling");
            currAction = CharacterActions.Idle;
        }



        if (currAction == CharacterActions.Move)
        {
            MoveToTarget();
            //Debug.Log("Moving");

            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPoint.transform.position, target.transform.position, fracJourney);
        }


    }

    void MoveToTarget()
    {
        
    }
}

public enum CharacterActions
{
    Idle,

    StartMove,
    Move,
}
