using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    public string charName;

    CharacterData data;

    public int efficiency;

    public float forestTime;// how long a character has been in the forest

    public int hopeLevel;
    public int carryWood;//how much wood the character is currently carrying

    public float deadTime;//time since this character has last spoken or perfomred an action

    public Character(CharacterData _data)
    {
        data = _data;
    }

	// Use this for initialization
	void Start () {
    

    }
	
	// Update is called once per frame
	void Update () {

        //UPDATE STORYS AND DIALOGUE
        foreach (DialogueStory story in data.HopefulStorys) { story.UpdateStory();}
        foreach (DialogueStory story in data.GhostStorys) { story.UpdateStory(); }

        foreach (Dialogue diag in data.needWoodPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.woodArrivesPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in data.lightDropPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.lightBoostPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.darknessPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in data.decreasedSanityPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.increasedSanityPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in data.positiveReactions) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.negativeReations) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in data.missionStartPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.missionEndPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.missionFailPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in data.missionSuceedPrompts) { diag.UpdateDialogue(); }

    }

    
    public DialogueStory ChooseStory(DialogueType _type)
    {
        List<Dialogue> dummyStory = new List<Dialogue>();
        dummyStory.Add(new Dialogue("Part 1 of a story", DialogueType.DarknessPrompt));
        dummyStory.Add(new Dialogue("Part 2 of a story", DialogueType.DarknessPrompt));

        DialogueStory chosenStory = new DialogueStory(dummyStory, DialogueType.Dummy);

        switch (_type)
        {
            case DialogueType.DarknessPrompt:
                break;

            case DialogueType.DecreasedSanityPrompt:

                break;

            default:
                
                break;



        }

        return chosenStory;
    }

    public Dialogue ChooseDialogue(DialogueType _type)
    {
        Dialogue chosenDiag = new Dialogue("default", DialogueType.Dummy);

        switch(_type)
        {        

            case DialogueType.NeedWoodPrompt:
                chosenDiag = GetOldestDialogue(data.needWoodPrompts);
                break;

            case DialogueType.WoodArrivesPrompt:
                chosenDiag = GetOldestDialogue(data.woodArrivesPrompts);
                break;

            case DialogueType.LightDropPrompt:
                chosenDiag = GetOldestDialogue(data.lightDropPrompts);
                break;

            case DialogueType.LightBoostPrompt:
                chosenDiag = GetOldestDialogue(data.lightBoostPrompts);
                break;

            case DialogueType.DarknessPrompt:
                chosenDiag = GetOldestDialogue(data.darknessPrompts);
                break;

            case DialogueType.DecreasedSanityPrompt:
                chosenDiag = GetOldestDialogue(data.decreasedSanityPrompts);
                break;

            case DialogueType.IncreasedSanityPrompt:
                chosenDiag = GetOldestDialogue(data.increasedSanityPrompts);
                break;

            case DialogueType.PositiveReaction:
                chosenDiag = GetOldestDialogue(data.positiveReactions);
                break;

            case DialogueType.NegativeReation:
                chosenDiag = GetOldestDialogue(data.negativeReations);
                break;

            case DialogueType.MissionStart:
                chosenDiag = GetOldestDialogue(data.missionStartPrompts);
                break;

            case DialogueType.MissionEnd:
                chosenDiag = GetOldestDialogue(data.missionEndPrompts);
                break;

            case DialogueType.MissionFail:
                chosenDiag = GetOldestDialogue(data.missionFailPrompts);
                break;

            case DialogueType.MissionSuceed:
                chosenDiag = GetOldestDialogue(data.missionSuceedPrompts);
                break;

            default:
                chosenDiag = new Dialogue("im a dummy value", DialogueType.Dummy);
                break;



        }

        return chosenDiag;
    }

    Dialogue GetOldestDialogue(List<Dialogue> source)
    {
        Debug.Log("1");

        Dialogue toReturn = source[0];
        float oldestTime = 0;

        Debug.Log("2");

        foreach (Dialogue diag in source)
        {
            if (diag.deadTime > oldestTime)
            {
                oldestTime = diag.deadTime;
                toReturn = diag;

                toReturn.deadTime = 0;
            }
        }

        return toReturn;
    }
}


