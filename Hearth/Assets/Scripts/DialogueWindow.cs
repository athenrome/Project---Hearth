using UnityEngine;
using System.Collections.Generic;

public class DialogueWindow : MonoBehaviour {

    public TextMesh diagText;

    List<Dialogue> toWrite = new List<Dialogue>();//the diaglogue to be written to screen

    string currText;

    

    public float lifeTime;//how long the text will stay active after it has finished writing
    float currLifetime = 0;

    public float letterInterval = 5; //time it takes between letter writes
    float currInterval;

    int currLine;//piece of dialogue that is currently being written
    int currLetter;

    bool finishedLine;

    public bool finished;
    bool stopped;
    

    // Use this for initialization
    void Start () {
        finished = false;
        finishedLine = false;
        stopped = false;
        diagText.text = "";//clear the text
        
	}

	// Update is called once per frame
	void Update () {

        if(finished == false && toWrite.Count > 0)
        {
            if (finishedLine == false)
            {
                if (currInterval <= 0)
                {
                    WriteLetter();
                    currInterval = letterInterval;
                }
                else
                {
                    currInterval -= Time.deltaTime;
                }
            }
            else
            {
                if(currLifetime <= 0)//pause for a while with text on scene
                {
                    currLine++;
                    if (currLine <= toWrite.Count)//is there another line
                    {
                        finishedLine = false;//keep writing
                    }
                    else//nothing more to write
                    {
                        finished = true;
                    }
                }
                else
                {
                    currLifetime -= Time.deltaTime;
                }
            }
            
            
        }
        else if(finished == true && stopped == false)//finish
        {
            Debug.Log("asd");
            currText = "";
            
            diagText.text = currText;
            
            currLine = 0;
            currLetter = 0;
            stopped = true;
            finished = true;

            Debug.Log("Finish Writing");
        }



        
	}

    public void WriteStory(DialogueStory _toWrite)
    {
        toWrite = _toWrite.storyText;
        diagText.text = "";
        currText = "";
        currLine = 0;
        currLetter = 0;
        finishedLine = true;
        finished = false;
        stopped = false;

        currInterval = letterInterval;
    }

    public void WriteDialogue(Dialogue _toWrite)
    {
        

        toWrite.Add(_toWrite);
        diagText.text = "";
        currText = "";
        currLine = 0;
        currLetter = 0;
        finishedLine = true;
        finished = false;
        stopped = false;

        currInterval = letterInterval;
        
    }


    void WriteLetter()
    {
        char nextchar = toWrite[currLine].text[currLetter];

        currText = currText + nextchar;

        diagText.text = currText;

        currLetter++;

        if(currLetter >= toWrite[currLine].length)
        {
            finishedLine = true;
            currLifetime = lifeTime;
        }
    }
}
