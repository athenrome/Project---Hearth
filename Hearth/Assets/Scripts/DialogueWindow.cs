using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueWindow : MonoBehaviour
{

    public TextMesh floatingText;

    public Text dialogueText;
    public Image TextboxPanel;

    List<Dialogue> toWrite = new List<Dialogue>();//the diaglogue to be written to screen

    string currText;


    string currDots = "";
    float dotLife;

    public float lifeTime;//how long the text will stay active after it has finished writing
    float currLifetime = 0;

    public static  float letterInterval = 0.025f; //time it takes between letter writes
    float currInterval;

    int currLine;//piece of dialogue that is currently being written
    int currLetter;

    bool finishedLine;

    public bool finished;
    bool stopped;

    bool fadeDirection;//true in false out

    public float letterWidth;
    public float letterHeight;


    bool fadeStatus;
    bool fading;
    float fadeLevel;


    // Use this for initialization
    void Start()
    {
        finished = true;
        fadeLevel = 0;
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);//clear text
        TextboxPanel.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);//clear panel

        //StartWriting();
        //FinishWriting();


    }

    // Update is called once per frame
    void Update()
    {

        WriteText();

        if(fading == true)
        {
            Fading();
        }

        


    }

    void WriteTalkingDots()
    {
        if (currDots.Length < 3)
        {
            currDots = currDots + ".";
            floatingText.text = currDots;
        }
        else
        {
            dotLife -= Time.deltaTime;

            if (dotLife <= 0)
            {
                currDots = "";
                floatingText.text = currDots;
            }
        }
    }

    void WriteText()
    {
        var prevfinished = finished;

        if (finished == false && toWrite.Count > 0)
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
                if (currLifetime <= 0)//pause for a while with text on scene
                {
                    currLine++;
                    //Debug.Log(currLine + " " + toWrite.Count);

                    if (currLine < toWrite.Count)//is there another line
                    {//reset for next line

                        dialogueText.text = "";//clear text
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


        if (finished == true && prevfinished != finished && stopped == false)//finish
        {
            FinishWriting();
        }
    }

    public void StartWriting()
    {
        finished = false;
        finishedLine = false;
        stopped = false;
        dialogueText.text = "";//clear the text
        floatingText.text = "";

    }

    public void FinishWriting()
    {

        currText = "";

        dialogueText.text = "";//clear the text
        floatingText.text = "";

        currLine = -1;
        currLetter = 0;
        stopped = true;
        finished = true;
        toWrite = new List<Dialogue>();//clear the list
        Debug.Log("Finish Writing");


        StartFadingOut();
    }

    public void WriteStory(DialogueStory _toWrite)
    {
        toWrite = _toWrite.storyText;
        dialogueText.text = "";
        currText = "";
        currLine = -1;
        currLetter = 0;
        finishedLine = true;
        finished = false;
        stopped = false;

        StartFadingIn();

        currInterval = letterInterval;
    }

    public void WriteDialogue(Dialogue _toWrite)
    {


        toWrite.Add(_toWrite);
        dialogueText.text = "";
        currText = "";
        currLine = -1;
        currLetter = 0;
        finishedLine = false;
        finished = false;
        stopped = false;

        StartFadingIn();

        currInterval = letterInterval;

    }

    void StartFadingIn()
    {
        fadeStatus = true;
        fading = true;

        fadeLevel = 0;
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);//clear text
        TextboxPanel.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);//clear panel
    }

    void StartFadingOut()
    {
        fadeStatus = false;
        fading = true;

    }

    void Fading()
    {
        if (fadeStatus == true && fading == true)//fade in
        {
            fadeLevel += Time.deltaTime / 2;

            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);
            TextboxPanel.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);
        }
        else if (fadeStatus == false && fading == true)//fade out
        {
            fadeLevel -= Time.deltaTime / 2;

            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);
            TextboxPanel.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, fadeLevel);
        }

        if(fadeStatus == true && fadeLevel >= 1)
        {
            fading = false;
        }
        else if (fadeStatus == true && fadeLevel <= 0)
        {
            fading = false;
        }
    }

    void WriteLetter()
    {
        WriteTalkingDots();

        if (currLine < 0)
            currLine = 0;

        char nextchar = toWrite[currLine].text[currLetter];

        currText = currText + nextchar;

        dialogueText.text = currText;

        currLetter++;

        if (currLetter >= toWrite[currLine].length)
        {
            finishedLine = true;
            currLifetime = lifeTime;
        }
    }

}
