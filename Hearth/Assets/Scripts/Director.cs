using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    List<Character> CharacterPool = new List<Character>();
    List<CharacterController> activeCharacters = new List<CharacterController>();
    List<Character> forestCharacters;

    public bool canTalk;

    int characterCount;
    int maxCharacters = 9;

    public int getWoodThreshold;//if wood is below this level send someone to get wood

    public GameObject characterPrefab;

    public Waypoint characterEntry;
    public Waypoint forestExit;




    public int unlockedPoints;//avalable point indexes
    public List<Waypoint> availablePoints;//waypoints closest to the fire



    public float spawnInterval;
    float currSpawnInterval;
    public int spawnChance;//chance for a character to spawn after the spawn interval

    bool woodRequested = false;



	// Use this for initialization
	void Start () {

        currSpawnInterval = 1;
        canTalk = true;
        CharacterPool.Add(new Character());//TESTING 
    }
	
	// Update is called once per frame
	void Update () {

        CheckFire();
        CheckWood();
        CheckCharacters();

    }

    void CheckFire()
    {
        unlockedPoints = firePit.fireSize;
    }

    void CheckWood()
    {
        if(woodPile.woodCount < getWoodThreshold)
        {
            woodRequested = true;
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
                    Waypoint movePoint = characterEntry;

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

    CharacterController SpawnCharacter()
    {
        characterCount++;

        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, characterEntry.transform.position, characterEntry.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        newChar.character = CharacterPool[0];//assign characer to new character

        activeCharacters.Add(newChar);

        Debug.Log("Spawned Character");

        return newChar;
        
    }


}
