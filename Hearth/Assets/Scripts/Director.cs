using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    List<Character> CharacterPool = new List<Character>();
    List<CharacterController> activeCharacters = new List<CharacterController>();
    List<Character> forestCharacters;

    int characterCount;
    int maxCharacters = 3;

    public GameObject characterPrefab;

    public Waypoint characterEntry;
    public Waypoint forestExit;




    int unlockedPoints = 9;//avalable point indexes
    public List<Waypoint> availablePoints;//waypoints closest to the fire



    public float spawnInterval;
    float currSpawnInterval;
    public int spawnChance;//chance for a character to spawn after the spawn interval

    CharacterActions actionRequest;



	// Use this for initialization
	void Start () {

        currSpawnInterval = spawnInterval;

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
        //enable or disable firepit slots
        if (firePit.fireSize >= 5) { unlockedPoints += 3; } else { unlockedPoints -= 3; }
        if (firePit.fireSize >= 10) { unlockedPoints += 3; } else { unlockedPoints -= 3; }
        if (firePit.fireSize >= 15) { unlockedPoints += 3; } else { unlockedPoints -= 3; }
    }

    void CheckWood()
    {

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
                    //SpawnCharacter();
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

        return newChar;
        
    }


}
