using UnityEngine;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {

    public string text;
    public DialogueTag tag;

    public bool available; //if this piece of dialogue can be used
    public float deadTime; //the time since this dialogue was last used

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
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