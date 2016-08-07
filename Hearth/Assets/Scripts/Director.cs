using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public FirePit firePit;
    public WoodPile woodPile;

    List<Character> CharacterPool = new List<Character>();
    List<CharacterController> activeCharacters = new List<CharacterController>();
    List<Character> forestCharacters;

    public GameObject characterPrefab;

    public Waypoint characterEntry;
    public Waypoint forestExit;




    int availablePoints = 9;

    bool closeActive;
    public List<Waypoint> closePoints;//waypoints closest to the fire
    int availableClose;

    bool midActive;
    public List<Waypoint> midPoints;
    int availableMid;

    bool farActive;
    public List<Waypoint> farPoints;
    int availableFar;

    public float spawnInterval;
    float currSpawnInterval;
    public int spawnChance;//chance for a character to spawn after the spawn interval




	// Use this for initialization
	void Start () {

        availableClose = closePoints.Count;
        availableMid = midPoints.Count;
        availableFar = farPoints.Count;

        availablePoints = availableClose + availableMid + availableFar;

        CharacterPool.Add(new Character());//TESTING 

        SpawnCharacter();

    }
	
	// Update is called once per frame
	void Update () {

        //enable or disable firepit slots
        if (firePit.fireSize >= 5) {closeActive = true;} else {closeActive = false;}
        if (firePit.fireSize >= 10) {midActive = true;} else {midActive = false; }
        if (firePit.fireSize >= 15) {farActive = true;} else {farActive = false; }


        if(currSpawnInterval <= 0)
        {
            int spawnChooser = Random.Range(0, 100);

            if(spawnChooser >= spawnChance)
            {
                SpawnCharacter();
            }

            currSpawnInterval = spawnInterval;
        }

    }


    void SpawnCharacter()
    {
        availablePoints--;

        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, characterEntry.transform.position, characterEntry.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        newChar.character = CharacterPool[0];//TESTING

        activeCharacters.Add(newChar);

        Waypoint targetPoint = characterEntry;//initlising to character entry

        if(availableClose > 0)
        {
            foreach(Waypoint point in closePoints)
            {
                if(point.occupied == false)
                {
                    targetPoint = point;
                }
            }
        }
        else if(availableMid > 0)
        {
            foreach (Waypoint point in midPoints)
            {
                if (point.occupied == false)
                {
                    targetPoint = point;
                }
            }
        }
        else if (availableFar > 0)
        {
            foreach (Waypoint point in farPoints)
            {
                if (point.occupied == false)
                {
                    targetPoint = point;
                }
            }
        }

        

        newChar.MoveToPoint(targetPoint, characterEntry);
        

        
    }


}
