using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int efficiency;

    GameObject characterModel;

    //STRINGS TO BE USED CREATE DIALOGUE

    public List<string> HopefulStorys1Text;
    public List<string> HopefulStorys2Text;
    public List<string> HopefulStorys3Text;

    public List<string> GhostStory1Text;
    public List<string> GhostStory2Text;
    public List<string> GhostStory3Text;

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

}


