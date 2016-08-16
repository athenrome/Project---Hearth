using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueWindow : MonoBehaviour {

    public TextMesh floatingText;
    public Text dialogueText;

    List<Dialogue> toWrite = new List<Dialogue>();//the diaglogue to be written to screen

    string currText;


    string currDots = "";
    float dotLife;

    public float lifeTime;//how long the text will stay active after it has finished writing
    float currLifetime = 0;

    public float letterInterval = 5; //time it takes between letter writes
    float currInterval;

    int currLine;//piece of dialogue that is currently being written
    int currLetter;

    bool finishedLine;

    public bool finished;
    bool stopped;

    bool fadeDirection;//true in false out

    public float letterWidth;
    public float letterHeight;

    
    

    // Use this for initialization
    void Start () {
        StartWriting();


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
                    //Debug.Log(currLine + " " + toWrite.Count);

                    if (currLine < toWrite.Count)//is there another line
                    {//reset for next line

                        SetDiaText("");//clear text
                        currText = "";
                        currLetter = 0;

                        finishedLine = false;//keep writing
                    }
                    else//nothing more to write
                    {
                        finished = true;
                        finishedLine = true;
                        

                    }
                }
                else
                {
                    currLifetime -= Time.deltaTime;
                }
            }
            
            
        }


        if(finished == true && stopped == false)//finish
        {
            FinishWriting();
        }



        
	}

    void WriteTalkingDots()
    {
        if(currDots.Length < 3)
        {
            currDots = currDots + ".";
            floatingText.text = currDots;
        }
        else
        {
            dotLife -= Time.deltaTime;

            if(dotLife <= 0)
            {
                currDots = "";
                floatingText.text = currDots;
            }
        }      
    }

    public void StartWriting()
    {
        finished = false;
        finishedLine = false;
        stopped = false;
        SetDiaText("");//clear the text
        floatingText.text = "";

        

    }

    void SetDiaText(string txt)
    {
        if(dialogueText != null)
            dialogueText.text = txt;
    }

    public void FinishWriting()
    {

        currText = "";

        SetDiaText("");//clear the text
        floatingText.text = "";

        currLine = 0;
        currLetter = 0;
        stopped = true;
        finished = true;
        toWrite = new List<Dialogue>();//clear the list
        Debug.Log("Finish Writing");
        
    }

    public void WriteStory(DialogueStory _toWrite)
    {
        toWrite = _toWrite.storyText;
        SetDiaText("");
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
        SetDiaText("");
        currText = "";
        currLine = 0;
        currLetter = 0;
        finishedLine = false;
        finished = false;
        stopped = false;

        currInterval = letterInterval;
        
    }


    void WriteLetter()
    {
        WriteTalkingDots();

        char nextchar = toWrite[currLine].text[currLetter];

        currText = currText + nextchar;

        SetDiaText( currText);

        currLetter++;

        if(currLetter >= toWrite[currLine].length)
        {
            finishedLine = true;
            currLifetime = lifeTime;
        }
    }

}
