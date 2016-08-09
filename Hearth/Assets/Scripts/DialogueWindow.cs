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

    int currDialogueLoc;//piece of dialogue that is currently being written
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
            if (currLetter < toWrite[currDialogueLoc].length)
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

        if(canWrite == false)
        {
            currLifetime -= Time.deltaTime;

            if(currLifetime <= 0)
            {
                if (currDialogueLoc + 1 < toWrite.Count)
                {
                    currDialogueLoc++;
                    canWrite = true;
                    Debug.Log("Next Line");
                }
                else
                {
                    diagText.text = "";
                }
            }
        }


        
	}

    public void WriteStory(List<Dialogue> _toWrite)
    {

    }

    public void WriteDialogue(Dialogue _toWrite)
    {
        toWrite.Add(_toWrite);
        currLetter = 0;
        canWrite = true;
    }

    public void HideWindow()
    {
        
    }

    void WriteLetter()
    {
        char nextchar = toWrite[currDialogueLoc].text[currLetter];

        currText = currText + nextchar;

        diagText.text = currText;

        currLetter++;

        if(currLetter >= toWrite[currDialogueLoc].length)
        {
            canWrite = false;
            currLifetime = lifeTime;
        }
    }
}
