using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int efficiency;

    GameObject characterModel;

    //STRINGS TO BE USED CREATE DIALOGUE

    public List<List<string>> HopefulStorysText;
    public List<List<string>> GhostStoryText;

    public List<string> needWoodPromptsText;
    public List<string> woodArrivesPromptsText;

    public List<string> lightDropPromptsText;
    public List<string> lightBoostPromptsText;
    public List<string> darknessPromptsText;

    public List<string> decreasedSanityPromptsText;
    public List<string> increasedSanityPromptsText;

    public List<string> positiveReactionsText;
    public List<string> negativeReationsText;

    public List<string> missionStartPromptsText;
    public List<string> missionEndPromptsText;
    public List<string> missionFailPromptsText;
    public List<string> missionSuceedPromptsText;


    public int IgnoreEverythingForward;

    public List<DialogueStory> HopefulStorys;
    public List<DialogueStory> GhostStorys;

    public List<Dialogue> needWoodPrompts;
    public List<Dialogue> woodArrivesPrompts;

    public List<Dialogue> lightDropPrompts;
    public List<Dialogue> lightBoostPrompts;
    public List<Dialogue> darknessPrompts;

    public List<Dialogue> decreasedSanityPrompts;
    public List<Dialogue> increasedSanityPrompts;

    public List<Dialogue> positiveReactions;
    public List<Dialogue> negativeReations;

    public List<Dialogue> missionStartPrompts;
    public List<Dialogue> missionEndPrompts;
    public List<Dialogue> missionFailPrompts;
    public List<Dialogue> missionSuceedPrompts;







    
}


