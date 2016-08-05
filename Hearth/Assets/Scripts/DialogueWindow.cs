using UnityEngine;
using System.Collections.Generic;

public class DialogueWindow : MonoBehaviour {

    public TextMesh diagText;

    Dialogue targetDialogue;//the diaglogue to be written to screen

    string toWrite;

    public float letterInterval = 50; //time it takes between letter writes
    float currInterval;

    int currLetter;

    bool written;

	// Use this for initialization
	void Start () {
        targetDialogue = new Dialogue("Ryan is an awesome fellow", DialogueTag.DarknessPrompt);
	
	}
	
	// Update is called once per frame
	void Update () {

        if(currLetter < targetDialogue.length)
        {
            if (currInterval > 0)
            {
                currInterval -= Time.deltaTime;
            }
            else
            {
                currInterval = letterInterval;
                WriteLetter();
            }
        }
	}


    void WriteLetter()
    {
        char nextchar = targetDialogue.text[currLetter];

        toWrite = toWrite + nextchar;

        diagText.text = toWrite;

        currLetter++;
    }
}
