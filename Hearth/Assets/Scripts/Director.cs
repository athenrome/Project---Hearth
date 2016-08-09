﻿using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    List<Character> CharacterPool = new List<Character>();
    public List<CharacterController> activeCharacters = new List<CharacterController>();
    public List<Character> forestCharacters = new List<Character>();

    CharacterController currActiveCharacter;

    public bool canTalk;

    public float deathChance;
    bool characterDeath;

    int characterCount;
    int maxCharacters = 9;

    public int getWoodThreshold;//if wood is below this level send someone to get wood

    public GameObject characterPrefab;

    public Waypoint entryPoint;
    public Waypoint forestPoint;

    public float forestReturnTime;//how logn a character spends in a forest before they reurn with wood
    public int gatherWoodCount; //how much wood characters bring back from the forest


    public int unlockedPoints;//avalable point indexes
    public List<Waypoint> availablePoints;//waypoints closest to the fire



    public float spawnInterval;
    float currSpawnInterval;
    public int spawnChance;//chance for a character to spawn after the spawn interval

    //order restrictions
    bool woodOrdered;



	// Use this for initialization
	void Start () {
        characterDeath = true;
        currSpawnInterval = 1;
        canTalk = true;
        CharacterPool.Add(new Character());//TESTING 
    }
	
	// Update is called once per frame
	void Update () {

        CheckFire();
        CheckWood();
        CheckForest();
        CheckCharacters();

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

        newChar.character = CharacterPool[0];//assign characer to new character

        activeCharacters.Add(newChar);
    }

    void CheckFire()
    {
        unlockedPoints = firePit.fireSize;
    }

    void CheckWood()
    {
        if(woodPile.woodCount < getWoodThreshold && woodOrdered == false)
        {
            OrderCharacter(GetActiveCharacter(), CharacterOrders.GetWood);
            woodOrdered = true;
        }
    }

    void CheckCharacters()
    {
        currSpawnInterval -= Time.deltaTime;

        if (currSpawnInterval <= 0)
        {
            int spawnChooser = Random.Range(0, 100);

            if (spawnChooser >= spawnChance)
            {
                if (characterCount < maxCharacters)
                {
                    CharacterController spawnedChar = SpawnCharacter();

                    bool foundMovePoint = false;
                    Waypoint movePoint = entryPoint;

                    for(int i = 0; i < unlockedPoints; i++)
                    {
                        if (foundMovePoint == false)
                        {
                            if (availablePoints[i].locked == false)
                            {
                                spawnedChar.MoveToPoint(availablePoints[i]);
                                foundMovePoint = true;
                                availablePoints[i].locked = true;
                            }
                        }
                        
                    }
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

        Debug.Log("Spawned Character");

        return newChar;
        
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


        currActiveCharacter = foundCharacter;

        return currActiveCharacter;
    }
}
