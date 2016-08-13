using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    public List<CharacterController> activeCharacters;// = new List<CharacterController>();

    public int getWoodThreshold;//if wood is below this level send someone to get wood
    
    public float stateTimeout;//time before a state can be changed again
    float currTimeout;
    bool stateChanged;//if the state has been changed



    public bool actionInProgress;
    public bool canChangeState;
    public bool canSpeak;


    [Range(0, 100)]
    public float storyChance;

    public float storyCooldown;//time since a story was told
    float currStoryCool;

    [Range(0,100)]
    public float moraleLevel;

    public WorldState currState;
    WorldState lastState;

	// Use this for initialization
	void Start () {
        actionInProgress = false;
        //currSpawnInterval = 1;
        currTimeout = 0;
        stateChanged = false;
        canSpeak = false;

        currStoryCool = storyCooldown;



        currState = WorldState.Idle;


    }
	
	// Update is called once per frame
	void Update () {

        CheckFire();
        CheckWood();

        if(actionInProgress == false)
        {
            CheckCharacterOrders();
        }

        if(stateChanged == false)
        {
            CheckWorldState();
        }

        //if (currStoryCool <= 0)
        //{
        //    if (canChangeState == true)
        //    {
        //        canSpeak = true;
        //        UpdateWorldState(WorldState.SpeakStory, false);
        //        Debug.Log("Story Time");
        //        canChangeState = false;
        //    }

        //}
        //else
        //{
        //    currStoryCool -= Time.deltaTime;
        //}


    }

    void CheckWorldState()
    {
        switch(currState)
        {
            case WorldState.NeedWood:
                Debug.Log("Wood Requested");

                UpdateWorldState(WorldState.SpeakDialogue, true);

                woodPile.AddWood(woodPile.maxWood);//fill the woood pile

                
                OrderCharacter(GetActiveCharacter(), CharacterOrders.RequestWood);


                break;

            case WorldState.SpeakDialogue:
                canSpeak = true;
                break;

            case WorldState.SpeakStory:

                int storyRoll = Random.Range(0, 100);

                if(storyRoll >= storyChance)
                {

                    

                    if (moraleLevel >= 50)
                    {
                        OrderCharacter(GetActiveCharacter(), CharacterOrders.SpeakHope);//hope story
                        Debug.Log("Hope story");
                    }
                    else
                    {
                        OrderCharacter(GetActiveCharacter(), CharacterOrders.SpeakGhost);//ghost story
                        Debug.Log("ghost story");
                    }
                }
                else
                {
                    Debug.Log("Failed story roll");
                }

                
                break;

            case WorldState.Idle:
                canChangeState = true;
                break;

            default:
                UpdateWorldState(WorldState.Idle, true);
                Debug.Log("invalid state idling");
                break;



        }
    }

    public void UpdateWorldState(WorldState newState, bool isCritical)
    {
        

        if(canChangeState == true || isCritical == true)
        {
            lastState = currState;//assign the old state to the last state

            currState = newState;//update the world state

            stateChanged = true;

            currTimeout = stateTimeout;

            Debug.Log("State Changed");
        }
        else
        {
            Debug.Log("Blocked state change");
        }

        if(isCritical == true)
        {
            stateChanged = false;
        }
        
    }

    void CheckCharacterOrders()//manages when and what is poken by ceratian characters
    {
        CharacterController toOrder = GetActiveCharacter();
        
    }

    void OrderCharacter(CharacterController character, CharacterOrders order)
    {
        character.ReceiveOrder(order);

        actionInProgress = true;

    }

    

    void CheckFire()
    {
        
    }

    void CheckWood()
    {
        if(woodPile.woodCount <= getWoodThreshold && woodPile.woodToAdd == 0 && currState == WorldState.Idle)
        {
            UpdateWorldState(WorldState.NeedWood, true);
            Debug.Log("wood ordered");
        }
    }

    void CheckCharacters()
    {
        foreach(CharacterController character in activeCharacters)//Update timesince last order
        {
            character.timeSinceLastAction += Time.deltaTime;
        }

    }

    CharacterController GetActiveCharacter()
    {
        CharacterController foundCharacter = activeCharacters[0];
        float score = 0;

        foreach (CharacterController character in activeCharacters)
        {
            if (character.timeSinceLastAction > score)
            {
                foundCharacter = character;
                score = character.timeSinceLastAction;
                
            }
        }

        foundCharacter.timeSinceLastAction = 0;
        



        return foundCharacter;
    }

}

public enum WorldState //usedto trigger events
{
    LightUp,
    LightDrop,
    
    
    FireEmbers,
    FireSmall,
    FireMed,
    FireBig,

    characterTalking,

    
    EnterForest,
    ForestDeath,
    ForestReturn,

    NeedWood,
    WoodGone,
    WoodFull,
    WoodConsumed,

    CharacterArrive,
    CharacterLeave,
    NoCharacters,

    GameStart,
    GameEnd,

    SpeakDialogue,
    SpeakStory,

    Idle,


}