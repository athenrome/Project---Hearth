using UnityEngine;
using System.Collections.Generic;

public class DialogueWindow : MonoBehaviour {

    public TextMesh diagText;

    Dialogue targetDialogue;//the diaglogue to be written to screen

    string toWrite;

    public float letterInterval = 5; //time it takes between letter writes
    float currInterval;

    int currLetter;

    bool canWrite;

	// Use this for initialization
	void Start () {
        diagText.text = "";//clear the text
	}

	// Update is called once per frame
	void Update () {

        if(canWrite == true)
        {
            if (currLetter < targetDialogue.length)
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

        
	}

    public void WriteDialogue(Dialogue _dialogue)
    {
        targetDialogue = _dialogue;
        currLetter = 0;
        canWrite = true;
    }

    void WriteLetter()
    {
        char nextchar = targetDialogue.text[currLetter];

        toWrite = toWrite + nextchar;

        diagText.text = toWrite;

        currLetter++;

        if(currLetter >= targetDialogue.length)
        {
            canWrite = false;
        }
    }
}
