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
    int availableClose = 3;

    bool midActive;
    public List<Waypoint> midPoints;
    int availableMid = 3;

    bool farActive;
    public List<Waypoint> farPoints;
    int availableFar = 3;

    public float spawnInterval;
    float currSpawnInterval;




	// Use this for initialization
	void Start () {

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
