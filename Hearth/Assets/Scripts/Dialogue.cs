using UnityEngine;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {

    public string text;
    public DialogueType type;
    public int length;//total number of letters to be written

    //public bool available; //if this piece of dialogue can be used
    public float deadTime; //the time since this dialogue was last used

    public Dialogue(string _text, DialogueType _type)
    {
        text = _text;
        type = _type;

        length = text.Length;
        deadTime = Random.Range(0,3);
    }

    public void UpdateDialogue()
    {
        deadTime += Time.deltaTime;
    }
}

public class DialogueStory
{
    public List<Dialogue> storyText;
    public DialogueType type;//only use ghost or hopeful story type

    public bool available; //if this piece of dialogue can be used
    public float deadTime; //the time since this dialogue was last used

    public DialogueStory(List<Dialogue> _storyDiag, DialogueType _type)
    {
        storyText = _storyDiag;
        type = _type;
    }

    public void UpdateStory()
    {
        if (available == false)
        {
            deadTime += Time.deltaTime;
        }
    }


}


public enum DialogueType
{
    NeedWoodPrompt,
    WoodArrivesPrompt,
    LightDropPrompt,
    LightBoostPrompt,
    DarknessPrompt,

    PositiveReaction,
    NegativeReation,

    MissionStart,
    MissionFail,
    MissionSuceed,

    HopefulStory,
    GhostStory,

    Dummy,

}