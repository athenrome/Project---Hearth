using UnityEngine;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {

    public string text;
    public DialogueTag tag;
    public int length;//total number of letters to be written

    public bool available; //if this piece of dialogue can be used
    public float deadTime; //the time since this dialogue was last used

    public Dialogue(string _text, DialogueTag _tag)
    {
        text = _text;
        tag = _tag;

        length = text.Length;
    }
}

public class DialogueStory
{
    public List<Dialogue> storyText;
    public StoryType type;

    public bool available; //if this piece of dialogue can be used
    public float deadTime; //the time since this dialogue was last used
}

public enum StoryType
{
    Hopeful,
    Ghost,
}

public enum DialogueTag
{
    NeedWoodPrompt,
    WoodArrivesPrompt,
    LightDropPrompt,
    LightBoostPrompt,
    DarknessPrompt,
    DecreasedSanityPrompt,
    IncreasedSanityPrompt,

    PositiveReaction,
    NegativeReation,

}