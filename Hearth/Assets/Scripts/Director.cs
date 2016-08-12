using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    public List<CharacterData> masterCharacterPool;
    public CharacterData survivorData;

    Character survivor;

    List<Character> CharacterPool = new List<Character>();

    public List<CharacterController> activeCharacters = new List<CharacterController>();
    public List<Character> forestCharacters = new List<Character>();

    //public float forestReturnTime;//how logn a character spends in a forest before they reurn with wood
    public int getWoodThreshold;//if wood is below this level send someone to get wood



    public float stateTimeout;//time before a state can be changed again
    float currTimeout;
    bool stateChanged;//if the state has been changed



    public bool actionInProgress;
    public bool canSpeak;



    int characterCount = 0;
    int maxCharacters;  

    public GameObject characterPrefab;

    public List<Waypoint> spawnPoints;//waypoints around the the fire
    public int unlockedPoints;

    //public List<Waypoint> forestPoints;
    //public Waypoint woodPilePoint;


    //[Range(0, 100)]
    //public int spawnChance;//chance for a character to spawn after the spawn interval

    //[Range(0, 100)]
    //public float deathChance;

    //public int unlockedPoints;//avalable point indexes
    
    //public float spawnInterval;
    //float currSpawnInterval;

    

    [Range(0,100)]
    public float moraleLevel;

    WorldState currState;
    WorldState lastState;


    public bool woodOrdered = false;

	// Use this for initialization
	void Start () {
        actionInProgress = false;
        //currSpawnInterval = 1;
        currTimeout = 0;
        stateChanged = false;
        

        LoadCharacters();

        maxCharacters = CharacterPool.Count;

        currState = WorldState.GameStart;

        SpawnCharacters();

    }
	
	// Update is called once per frame
	void Update () {

        CheckFire();
        CheckWood();

        if(actionInProgress == false)
        {
            CheckCharacterOrders();
        }


        
        if(currTimeout <= 0)
        {
            CheckWorldState();

            if(stateChanged == true)
            {
                currTimeout = stateTimeout;
            }
        }
        else
        {
            currTimeout -= Time.deltaTime;
        }
        

        
    }

    void CheckWorldState()
    {
        switch(currState)
        {
            case WorldState.NeedWood:

                OrderCharacter(GetActiveCharacter(), CharacterOrders.RequestWood);

                woodOrdered = true;

                woodPile.AddWood(woodPile.maxWood - woodPile.woodCount);//fill the woood pile

                UpdateWorldState(WorldState.Idle);
                break;





        }
    }

    public void UpdateWorldState(WorldState newState)
    {
        lastState = currState;//assign the old state to the last state

        currState = newState;//update the world state

        stateChanged = true;

        currTimeout = stateTimeout;
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
        unlockedPoints = firePit.fireSize;
    }

    void CheckWood()
    {
        if(woodPile.woodCount <= getWoodThreshold && woodOrdered == false && woodPile.woodToAdd == 0 && currState != WorldState.NeedWood)
        {
            UpdateWorldState(WorldState.NeedWood);            
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




        return foundCharacter;
    }

    void LoadCharacters()
    {

        survivor = new Character(survivorData);

        foreach (CharacterData character in masterCharacterPool)
        {
            CharacterPool.Add(new Character(character));
            Debug.Log("Loaded character: " + character.characterName);
        }
    }

    public Character GetCharacter()
    {
        Character toReturn = survivor;

        if(CharacterPool.Count > 0)
        {
            int index = Random.Range(0, CharacterPool.Count);

            toReturn = CharacterPool[index];
            CharacterPool.Remove(toReturn);
        }

        return toReturn;
    }

    void SpawnCharacters()
    {
        for(int i = 0; characterCount < unlockedPoints; i++)
        {
            if(spawnPoints[i].locked == false)
            {
                SpawnCharacter(GetFreePoint());
            }
        }
    }

    void SpawnCharacter(Waypoint spawnPoint)
    {     

        characterCount++;

        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        if (CharacterPool.Count > 0)
        {
            newChar.character = CharacterPool[0];//assign characer to new character choose the oldest cahracter

            CharacterPool.Remove(newChar.character);//remove this character from circulation

        }
        else
        {
            newChar.character = survivor;

        }

        activeCharacters.Add(newChar);
        
        Debug.Log("Spawned Character: " + newChar.character.charName);
    }

    public Waypoint GetFreePoint()
    {
        Waypoint foundPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];//choose a random point out of the forsest points

        spawnPoints.Remove(foundPoint);//remove point from circulation

        return foundPoint;
    }





    //Waypoint FindFreeFireSpot()
    //{
    //    Waypoint freeSpot = availablePoints[0];

    //    bool foundPoint = false;

    //    for(int i = 0; i < unlockedPoints || foundPoint == false; i++)
    //    {
    //        if(availablePoints[i].locked == false)
    //        {
    //            freeSpot = availablePoints[i];
    //            foundPoint = true;

    //            Debug.Log("Found Point");
    //        }


    //    }


    //    return freeSpot;
    //}

    //void CheckForest()
    //{
    //    if(forestCharacters.Count > 0)
    //    {
    //        foreach(Character character in forestCharacters)
    //        {
    //            character.forestTime += Time.deltaTime;

    //            if (character.forestTime >= forestReturnTime)//return or die character
    //            {
    //                int deathRoll = Random.Range(0, 100);

    //                if (deathRoll >= deathChance)//return character
    //                {
    //                    ReturnForestCharacter(character);
    //                    forestCharacters.Remove(character);
    //                    Debug.Log("CHARACTER RETURN");
    //                }
    //                else//character dies
    //                {
    //                    UpdateWorldState(WorldState.ForestDeath);
    //                    forestCharacters.Remove(character);
    //                    characterCount--;
    //                    Debug.Log("CHARACTER DEATH");
    //                }


    //            }
    //        }


    //    }
    //}

    //void ReturnForestCharacter(Character _toReturn)
    //{
    //    Waypoint forestPoint = GetForestPoint();

    //    GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, forestPoint.transform.position, forestPoint.transform.rotation) as GameObject;

    //    CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

    //    newChar.character = forestCharacters[0];//assign characer to new character





    //    forestCharacters.Remove(newChar.character);
    //    activeCharacters.Add(newChar);

    //    newChar.character.carryWood = Random.Range(0, newChar.character.efficiency);//

    //    //after return actions
    //    newChar.MoveToPoint(woodPilePoint);

    //}
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

    HopefulStory,
    GhostStory,

    Idle,


}