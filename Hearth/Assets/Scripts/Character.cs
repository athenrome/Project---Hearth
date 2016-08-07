using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    public string charName;

    public bool isCharacter;

    List<DialogueStory> HopefulStorys;
    List<DialogueStory> GhostStorys;

    List<Dialogue> NeedWoodPrompts;
    List<Dialogue> WoodArrivesPrompts;

    List<Dialogue> LightDropPrompts;
    List<Dialogue> LightBoostPrompts;

    List<Dialogue> darknessPrompts;    

    List<Dialogue> DecreasedSanityPrompts;
    List<Dialogue> IncreasedSanityPrompts;

    List<Dialogue> PositiveReactions;
    List<Dialogue> NegativeReations;

    

    public int efficiency;
    public int hopeLevel;

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

    

    public Dialogue ChooseDialogue(DialogueType _type)
    {
        Dialogue chosenDiag = new Dialogue("im a dummy value", DialogueType.Dummy);

        float diagScore = 0;

        switch(_type)
        {
            case DialogueType.DarknessPrompt:
                break;

            case DialogueType.DecreasedSanityPrompt:

                break;

            case DialogueType.IncreasedSanityPrompt:

                break;

            case DialogueType.LightBoostPrompt:

                break;

            case DialogueType.LightDropPrompt:

                break;

            case DialogueType.NeedWoodPrompt:

                break;

            case DialogueType.NegativeReation:

                break;

            case DialogueType.PositiveReaction:

                break;

            case DialogueType.WoodArrivesPrompt:

                break;

            default:
                chosenDiag = new Dialogue("im a dummy value", DialogueType.Dummy);
                break;



        }
        chosenDiag = new Dialogue("im a dummy value", DialogueType.Dummy);

        return chosenDiag;
    }
}


