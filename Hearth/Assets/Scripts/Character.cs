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

    public List<DialogueStory> HopefulStorys = new List<DialogueStory>();
    public List<DialogueStory> GhostStorys = new List<DialogueStory>();

    public List<Dialogue> needWoodPrompts = new List<Dialogue>();
    public List<Dialogue> woodArrivesPrompts = new List<Dialogue>();

    public List<Dialogue> lightDropPrompts = new List<Dialogue>();
    public List<Dialogue> lightBoostPrompts = new List<Dialogue>();
    public List<Dialogue> darknessPrompts = new List<Dialogue>();

    public List<Dialogue> decreasedSanityPrompts = new List<Dialogue>();
    public List<Dialogue> increasedSanityPrompts = new List<Dialogue>();

    public List<Dialogue> positiveReactions = new List<Dialogue>();
    public List<Dialogue> negativeReations = new List<Dialogue>();

    public List<Dialogue> missionStartPrompts = new List<Dialogue>();
    public List<Dialogue> missionEndPrompts = new List<Dialogue>();
    public List<Dialogue> missionFailPrompts = new List<Dialogue>();
    public List<Dialogue> missionSuceedPrompts = new List<Dialogue>();

    public Character(CharacterData _data)
    {
        data = _data;
        charName = data.characterName;

        GetDialogueData();
    }

	// Use this for initialization
	void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

        //UPDATE STORYS AND DIALOGUE
        foreach (DialogueStory story in HopefulStorys) { story.UpdateStory();}
        foreach (DialogueStory story in GhostStorys) { story.UpdateStory(); }

        foreach (Dialogue diag in needWoodPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in woodArrivesPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in lightDropPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in lightBoostPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in darknessPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in decreasedSanityPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in increasedSanityPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in positiveReactions) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in negativeReations) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in missionStartPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in missionEndPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in missionFailPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in missionSuceedPrompts) { diag.UpdateDialogue(); }

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
                
                chosenDiag = GetOldestDialogue(needWoodPrompts);
                break;

            case DialogueType.WoodArrivesPrompt:
                chosenDiag = GetOldestDialogue(woodArrivesPrompts);
                break;

            case DialogueType.LightDropPrompt:
                chosenDiag = GetOldestDialogue(lightDropPrompts);
                break;

            case DialogueType.LightBoostPrompt:
                chosenDiag = GetOldestDialogue(lightBoostPrompts);
                break;

            case DialogueType.DarknessPrompt:
                chosenDiag = GetOldestDialogue(darknessPrompts);
                break;

            case DialogueType.DecreasedSanityPrompt:
                chosenDiag = GetOldestDialogue(decreasedSanityPrompts);
                break;

            case DialogueType.IncreasedSanityPrompt:
                chosenDiag = GetOldestDialogue(increasedSanityPrompts);
                break;

            case DialogueType.PositiveReaction:
                chosenDiag = GetOldestDialogue(positiveReactions);
                break;

            case DialogueType.NegativeReation:
                chosenDiag = GetOldestDialogue(negativeReations);
                break;

            case DialogueType.MissionStart:
                chosenDiag = GetOldestDialogue(missionStartPrompts);
                break;

            case DialogueType.MissionEnd:
                chosenDiag = GetOldestDialogue(missionEndPrompts);
                break;

            case DialogueType.MissionFail:
                chosenDiag = GetOldestDialogue(missionFailPrompts);
                break;

            case DialogueType.MissionSuceed:
                chosenDiag = GetOldestDialogue(missionSuceedPrompts);
                break;

            default:
                chosenDiag = new Dialogue("im a dummy value", DialogueType.Dummy);
                break;



        }

        return chosenDiag;
    }

    Dialogue GetOldestDialogue(List<Dialogue> source)
    {
        Dialogue toReturn = source[0];
        float oldestTime = 0;

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

    void GetDialogueData()
    {
        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.NeedWoodPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.WoodArrivesPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.LightDropPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.LightBoostPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.DarknessPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.DecreasedSanityPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.IncreasedSanityPrompt));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.PositiveReaction));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.NegativeReation));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionStart));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionEnd));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionFail));
        }

        foreach (string text in data.needWoodPromptsText)
        {
            needWoodPrompts.Add(new Dialogue(text, DialogueType.MissionSuceed));
        }
    }
}


