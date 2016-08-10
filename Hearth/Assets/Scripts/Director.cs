using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    public List<CharacterData> masterCharacterPool;

    List<Character> CharacterPool = new List<Character>();

    public List<CharacterController> activeCharacters = new List<CharacterController>();
    public List<Character> forestCharacters = new List<Character>();

    bool canTalk;

    public float orderCooldown;//how long before a new action can be made
    float currOrderCooldown = 0;
    public bool actionTaken;

    public float forestReturnTime;//how logn a character spends in a forest before they reurn with wood
    public int gatherWoodCount; //how much wood characters bring back from the forest
    public int getWoodThreshold;//if wood is below this level send someone to get wood

    

    bool characterDeath;

    int characterCount;
    int maxCharacters;

    bool askedForWood;//if a wood request has been given
    bool woodOrdered;//if someone has been sent to get wood

   

    public GameObject characterPrefab;

    public List<Waypoint> availablePoints;//waypoints closest to the fire
    public Waypoint entryPoint;
    public Waypoint forestPoint;
    public Waypoint woodPilePoint;


    [Range(0, 100)]
    public int spawnChance;//chance for a character to spawn after the spawn interval

    [Range(0, 100)]
    public float deathChance;

    public int unlockedPoints;//avalable point indexes
    
    public float spawnInterval;
    float currSpawnInterval;

    

    [Range(0,100)]
    public float moraleLevel;


	// Use this for initialization
	void Start () {
        characterDeath = true;
        currSpawnInterval = 1;
        canTalk = true;
        actionTaken = false;

        LoadCharacters();

        SpawnCharacter();
    }
	
	// Update is called once per frame
	void Update () {

        CheckFire();
        CheckWood();
        CheckForest();
        CheckCharacters();


        
        if (currOrderCooldown <= 0)
        {
            CheckCharacterOrders();

            if (actionTaken == true)
            {
                currOrderCooldown = orderCooldown;
            }

        }
        else
        {
            currOrderCooldown -= Time.deltaTime;
        }
    }



    void CheckCharacterOrders()//manages when and what is poken by ceratian characters
    {
        CharacterController toOrder = GetActiveCharacter();
        
        if(actionTaken = false && activeCharacters.Count > 0)
        {
            toOrder.Speak(DialogueType.NeedWoodPrompt);
            Debug.Log("asdf");
        }

        
    }

    void CheckForest()
    {
        if(forestCharacters.Count > 0)
        {
            foreach(Character character in forestCharacters)
            {
                character.forestTime += Time.deltaTime;

                if (character.forestTime >= forestReturnTime)//return or die character
                {
                    int deathRoll = Random.Range(0, 100);

                    if (deathRoll >= deathChance)//return character
                    {
                        ReturnForestCharacter(character);
                        forestCharacters.Remove(character);
                        Debug.Log("CHARACTER RETURN");
                    }
                    else//character dies
                    {
                        characterDeath = true;
                        forestCharacters.Remove(character);
                        characterCount--;
                        Debug.Log("CHARACTER DEATH");
                    }

                    
                }
            }


        }
    }

    void ReturnForestCharacter(Character _toReturn)
    {
        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, forestPoint.transform.position, forestPoint.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        newChar.character = forestCharacters[0];//assign characer to new character



        

        forestCharacters.Remove(newChar.character);
        activeCharacters.Add(newChar);

        //after return actions
        newChar.MoveToPoint(woodPilePoint);
        newChar.character.carryWood = Random.Range(0, newChar.character.efficiency);
    }

    void CheckFire()
    {
        unlockedPoints = firePit.fireSize;
    }

    void CheckWood()
    {
        if(woodPile.woodCount < getWoodThreshold && woodOrdered == false)
        {
            //OrderCharacter(GetActiveCharacter(), CharacterOrders.GetWood);
            askedForWood = true;
        }
    }

    void CheckCharacters()
    {
        foreach(CharacterController character in activeCharacters)//Update timesince last order
        {
            character.timeSinceLastAction += Time.deltaTime;
        }


        currSpawnInterval -= Time.deltaTime;

        if (currSpawnInterval <= 0)
        {
            int spawnChooser = Random.Range(0, 100);

            if (spawnChooser >= spawnChance)
            {
                if (characterCount < maxCharacters)
                {
                    CharacterController spawnedChar = SpawnCharacter();
                }

            }

            currSpawnInterval = spawnInterval;
        }       

    }

    public void OrderCharacter(CharacterController character, CharacterOrders order)
    {
        character.ReceiveOrder(order);
    }

    CharacterController SpawnCharacter()
    {
        characterCount++;

        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, entryPoint.transform.position, entryPoint.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        newChar.character = CharacterPool[0];//assign characer to new character

        activeCharacters.Add(newChar);

        Debug.Log("Spawned Character: " + newChar.character.charName);

        GoToStartPos(newChar);

        return newChar;
        
    }

    void GoToStartPos(CharacterController character)
    {
        bool foundMovePoint = false;
        Waypoint movePoint = entryPoint;

        for (int i = 0; i < unlockedPoints; i++)
        {
            if (foundMovePoint == false)
            {
                if (availablePoints[i].locked == false)
                {
                    character.MoveToPoint(availablePoints[i]);
                    foundMovePoint = true;
                    availablePoints[i].locked = true;
                    Debug.Log("Found starting pos");
                }
            }

        }
    }

    CharacterController GetActiveCharacter()
    {
        CharacterController foundCharacter = activeCharacters[0];
        float score = 0;

        foreach(CharacterController character in activeCharacters)
        {
            if(character.timeSinceLastAction > score)
            {
                foundCharacter = character;
                score = character.timeSinceLastAction;
            }
        }


        Debug.Log("Active character is: " + foundCharacter.character.charName);

        return foundCharacter;
    }

    void LoadCharacters()
    {

        foreach (CharacterData character in masterCharacterPool)
        {
            ProcessDialogueData(character);
            CharacterPool.Add(new Character(character));
            Debug.Log("Created character: " + CharacterPool.Count + character.characterName);
        }
    }

    void ProcessDialogueData(CharacterData character)
    {
        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.NeedWoodPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.WoodArrivesPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.LightDropPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.LightBoostPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.DarknessPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.DecreasedSanityPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.IncreasedSanityPrompt));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.PositiveReaction));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.NegativeReation));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionStart));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionEnd));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionFail));
        }

        foreach (string text in character.needWoodPromptsText)
        {
            character.needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionSuceed));
        }
    }
}
