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

    public List<Dialogue> positiveReactions = new List<Dialogue>();
    public List<Dialogue> negativeReations = new List<Dialogue>();

    public List<Dialogue> missionStartPrompts = new List<Dialogue>();
    public List<Dialogue> missionFailPrompts = new List<Dialogue>();
    public List<Dialogue> missionSuceedPrompts = new List<Dialogue>();

    public Character(CharacterData _data)
    {
        data = _data;
        charName = data.characterName;

        GetDialogueData();
        GetStoryData();

        Debug.Log("Created character: " + charName);
    }

	// Use this for initialization
	void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {

        

    }

    public void UpdateCharacterDialogue()
    {
        //UPDATE STORYS AND DIALOGUE
        foreach (DialogueStory story in HopefulStorys) { story.UpdateStory(); }
        foreach (DialogueStory story in GhostStorys) { story.UpdateStory(); }

        foreach (Dialogue diag in needWoodPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in woodArrivesPrompts) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in lightDropPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in lightBoostPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in darknessPrompts) { diag.UpdateDialogue(); }


        foreach (Dialogue diag in positiveReactions) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in negativeReations) { diag.UpdateDialogue(); }

        foreach (Dialogue diag in missionStartPrompts) { diag.UpdateDialogue(); }
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
            case DialogueType.GhostStory:
                chosenStory = GetOldestStory(GhostStorys);
                break;

            case DialogueType.HopefulStory:
                chosenStory = GetOldestStory(HopefulStorys);
                break;


            default:
                
                break;



        }

        return chosenStory;
    }

    public Dialogue ChooseDialogue(DialogueType _type)
    {
        Dialogue chosenDiag = new Dialogue("default", DialogueType.Dummy);



        switch (_type)
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

            case DialogueType.PositiveReaction:
                chosenDiag = GetOldestDialogue(positiveReactions);
                break;

            case DialogueType.NegativeReation:
                chosenDiag = GetOldestDialogue(negativeReations);
                break;

            case DialogueType.MissionStart:
                chosenDiag = GetOldestDialogue(missionStartPrompts);
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

    DialogueStory GetOldestStory(List<DialogueStory> source)
    {
        DialogueStory toReturn = source[0];
        float oldestTime = 0;

        foreach (DialogueStory diag in source)
        {
            if (diag.deadTime > oldestTime)
            {
                oldestTime = diag.deadTime;
                toReturn = diag;

                diag.deadTime = 0;
            }
        }

        toReturn.deadTime = 0;

        return toReturn;
    }



    void GetDialogueData()
    {
        foreach (string text in data.needWoodPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.NeedWoodPrompt);
            needWoodPrompts.Add(newDialogue);
        }

        foreach (string text in data.woodArrivesPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.WoodArrivesPrompt);
            woodArrivesPrompts.Add(newDialogue);
        }

        foreach (string text in data.lightDropPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.LightDropPrompt);
            lightDropPrompts.Add(newDialogue);
        }

        foreach (string text in data.lightBoostPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.LightBoostPrompt);
            lightBoostPrompts.Add(newDialogue);
        }

        foreach (string text in data.darknessPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.DarknessPrompt);
            darknessPrompts.Add(newDialogue);
        }

        foreach (string text in data.positiveReactionsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.PositiveReaction);
            positiveReactions.Add(newDialogue);
        }

        foreach (string text in data.negativeReationsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.NegativeReation);
            negativeReations.Add(newDialogue);
        }

        foreach (string text in data.missionStartPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.MissionStart);
            missionStartPrompts.Add(newDialogue);
        }

        foreach (string text in data.missionFailPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.MissionFail);
            missionFailPrompts.Add(newDialogue);
        }

        foreach (string text in data.missionSuceedPromptsText)
        {
            Dialogue newDialogue = new Dialogue(text, DialogueType.MissionSuceed);
            missionSuceedPrompts.Add(newDialogue);
        }


    }

    void GetStoryData()
    {
        List<Dialogue> hope1Diag = new List<Dialogue>();
        List<Dialogue> hope2Diag = new List<Dialogue>();
        List<Dialogue> hope3Diag = new List<Dialogue>();

        List<Dialogue> ghost1Diag = new List<Dialogue>();
        List<Dialogue> ghost2Diag = new List<Dialogue>();
        List<Dialogue> ghost3Diag = new List<Dialogue>();


        //HOPEFUL
        foreach (string text in data.HopefulStorys1Text)
        {
            hope1Diag.Add(new Dialogue(text, DialogueType.HopefulStory));
        }

        HopefulStorys.Add(new DialogueStory(hope1Diag, DialogueType.HopefulStory));



        foreach (string text in data.HopefulStorys2Text)
        {
            hope2Diag.Add(new Dialogue(text, DialogueType.HopefulStory));
        }

        HopefulStorys.Add(new DialogueStory(hope2Diag, DialogueType.HopefulStory));



        foreach (string text in data.HopefulStorys3Text)
        {
            hope3Diag.Add(new Dialogue(text, DialogueType.HopefulStory));
        }

        HopefulStorys.Add(new DialogueStory(hope3Diag, DialogueType.HopefulStory));







        //GHOST
        foreach (string text in data.GhostStory1Text)
        {
            ghost1Diag.Add(new Dialogue(text, DialogueType.GhostStory));
        }

        GhostStorys.Add(new DialogueStory(ghost1Diag, DialogueType.GhostStory));



        foreach (string text in data.GhostStory2Text)
        {
            ghost2Diag.Add(new Dialogue(text, DialogueType.GhostStory));
        }

        GhostStorys.Add(new DialogueStory(hope2Diag, DialogueType.GhostStory));



        foreach (string text in data.GhostStory3Text)
        {
            ghost3Diag.Add(new Dialogue(text, DialogueType.GhostStory));
        }

        GhostStorys.Add(new DialogueStory(hope3Diag, DialogueType.GhostStory));
    }
}


