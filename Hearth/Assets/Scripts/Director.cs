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

   

    


    bool closeActive;
    public List<Waypoint> closePoints;//waypoints closest to the fire

    bool midActive;
    public List<Waypoint> midPoints;

    bool farActive;
    public List<Waypoint> farPoints;

    public float spawnInterval;
    float currSpawnInterval;




	// Use this for initialization
	void Start () {
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
        GameObject spawnedCharObj = GameObject.Instantiate(characterPrefab, characterEntry.transform.position, characterEntry.transform.rotation) as GameObject;

        CharacterController newChar = spawnedCharObj.GetComponent<CharacterController>();

        newChar.character = CharacterPool[0];//TESTING

        activeCharacters.Add(newChar);




        newChar.MoveToPoint(closePoints[0], characterEntry);
        

        
    }


}
