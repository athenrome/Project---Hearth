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

        currSpawnInterval = spawnInterval;

        availablePoints = availableClose + availableMid + availableFar;

        CharacterPool.Add(new Character());//TESTING 
    }
	
	// Update is called once per frame
	void Update () {

        //enable or disable firepit slots
        if (firePit.fireSize >= 5) {closeActive = true;} else {closeActive = false;}
        if (firePit.fireSize >= 10) {midActive = true;} else {midActive = false; }
        if (firePit.fireSize >= 15) {farActive = true;} else {farActive = false; }


        currSpawnInterval -= Time.deltaTime;

        if(currSpawnInterval <= 0)
        {
            int spawnChooser = Random.Range(0, 100);

            if(spawnChooser >= spawnChance)
            {
                if(characterCount < maxCharacters)
                {
                    //SpawnCharacter();
                }
                
            }

            currSpawnInterval = spawnInterval;
        }

    }


    void SpawnCharacter()
    {
        characterCount++;
        availablePoints--;

        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, characterEntry.transform.position, characterEntry.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        newChar.character = CharacterPool[0];//TESTING

        activeCharacters.Add(newChar);

        Waypoint targetPoint = characterEntry;//initlising to character entry

        int pointLoc = 0;

        if(availableClose > 0)
        {
            for(int i = 0; i < closePoints.Count; i++)
            {
                if(closePoints[i].occupied == false)
                {
                    targetPoint = closePoints[i];
                    pointLoc = i;
                }
            }
        }
        //else if(availableMid > 0)
        //{
        //    for (int i = 0; i < midPoints.Count; i++)
        //    {
        //        if (midPoints[i].occupied == false)
        //        {
        //            targetPoint = midPoints[i];
        //        }
        //    }
        //}
        //else if (availableFar > 0)
        //{
        //    for (int i = 0; i < farPoints.Count; i++)
        //    {
        //        if (farPoints[i].occupied == false)
        //        {
        //            targetPoint = farPoints[i];
        //        }
        //    }
        //}


        closePoints[pointLoc].occupied = true;
        newChar.MoveToPoint(targetPoint, characterEntry);
        

        
    }


}
