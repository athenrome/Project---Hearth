using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    public string charName;

    public int efficiency;

    List<DialogueStory> HopefulStorys = new List<DialogueStory>();
    List<DialogueStory> GhostStorys = new List<DialogueStory>();

    List<Dialogue> NeedWoodPrompts = new List<Dialogue>();
    List<Dialogue> WoodArrivesPrompts = new List<Dialogue>();

    List<Dialogue> LightDropPrompts = new List<Dialogue>();
    List<Dialogue> LightBoostPrompts = new List<Dialogue>();

    List<Dialogue> darknessPrompts = new List<Dialogue>();

    List<Dialogue> DecreasedSanityPrompts = new List<Dialogue>();
    List<Dialogue> IncreasedSanityPrompts = new List<Dialogue>();

    List<Dialogue> PositiveReactions = new List<Dialogue>();
    List<Dialogue> NegativeReations = new List<Dialogue>();

    public float forestTime;// how long a character has been in the forest

    public int hopeLevel;
    public int carryWood;//how much wood the character is currently carrying

    public float deadTime;//time since this character has last spoken or perfomred an action

    public Character()
    {

    }

	// Use this for initialization
	void Start () {
        NeedWoodPrompts.Add(new Dialogue("asdf1", DialogueType.NeedWoodPrompt));
        NeedWoodPrompts.Add(new Dialogue("asdf2", DialogueType.NeedWoodPrompt));
        NeedWoodPrompts.Add(new Dialogue("asdf3", DialogueType.NeedWoodPrompt));
        NeedWoodPrompts.Add(new Dialogue("asdf4", DialogueType.NeedWoodPrompt));

        

    }
	
	// Update is called once per frame
	void Update () {

        //UPDATE STORYS AND DIALOGUE
        foreach (DialogueStory story in HopefulStorys) { story.UpdateStory();}
        foreach (DialogueStory story in GhostStorys) { story.UpdateStory(); }

        foreach (Dialogue diag in NeedWoodPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in WoodArrivesPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in LightDropPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in LightBoostPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in darknessPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in DecreasedSanityPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in IncreasedSanityPrompts) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in PositiveReactions) { diag.UpdateDialogue(); }
        foreach (Dialogue diag in NegativeReations) { diag.UpdateDialogue(); }

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
            case DialogueType.DarknessPrompt:
                chosenDiag = GetOldestDialogue(darknessPrompts);
                break;

            case DialogueType.DecreasedSanityPrompt:
                chosenDiag = GetOldestDialogue(DecreasedSanityPrompts);
                break;

            case DialogueType.IncreasedSanityPrompt:
                chosenDiag = GetOldestDialogue(IncreasedSanityPrompts);
                break;

            case DialogueType.LightBoostPrompt:
                chosenDiag = GetOldestDialogue(LightBoostPrompts);

                break;

            case DialogueType.LightDropPrompt:
                chosenDiag = GetOldestDialogue(LightDropPrompts);
                break;

            case DialogueType.NeedWoodPrompt:

                Debug.Log("a");

                Dialogue toReturn = NeedWoodPrompts[0];
                float oldestTime = 0;

                foreach (Dialogue diag in NeedWoodPrompts)
                {
                    if (diag.deadTime > oldestTime)
                    {
                        oldestTime = diag.deadTime;
                        toReturn = diag;

                        toReturn.deadTime = 0;
                    }
                }

                chosenDiag = toReturn;

                break;

            case DialogueType.NegativeReation:
                chosenDiag = GetOldestDialogue(NegativeReations);
                break;

            case DialogueType.PositiveReaction:
                chosenDiag = GetOldestDialogue(PositiveReactions);
                break;

            case DialogueType.WoodArrivesPrompt:
                chosenDiag = GetOldestDialogue(WoodArrivesPrompts);
                break;

            default:
                chosenDiag = new Dialogue("im a dummy value", DialogueType.Dummy);
                break;



        }

        return chosenDiag;
    }

    Dialogue GetOldestDialogue(List<Dialogue> source)
    {
        //Debug.Log("1");

        Dialogue toReturn = source[0];
        //float oldestTime = 0;

        //Debug.Log("2");

        //foreach (Dialogue diag in source)
        //{
        //    if(diag.deadTime > oldestTime)
        //    {
        //        oldestTime = diag.deadTime;
        //        toReturn = diag;

        //        toReturn.deadTime = 0;
        //    }
        //}

        return toReturn;
    }
}


