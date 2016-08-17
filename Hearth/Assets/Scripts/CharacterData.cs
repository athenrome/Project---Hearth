using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int efficiency;

    GameObject characterModel;

    //STRINGS TO BE USED CREATE DIALOGUE

        [TextArea]
    public List<string> HopefulStorys1Text;

    [TextArea]
    public List<string> HopefulStorys2Text;

    [TextArea]
    public List<string> HopefulStorys3Text;

    [TextArea]
    public List<string> GhostStory1Text;

    [TextArea]
    public List<string> GhostStory2Text;

    [TextArea]
    public List<string> GhostStory3Text;

    [TextArea]
    public List<string> needWoodPromptsText;

    [TextArea]
    public List<string> woodArrivesPromptsText;

    [TextArea]
    public List<string> lightDropPromptsText;

    [TextArea]
    public List<string> lightBoostPromptsText;

    [TextArea]
    public List<string> darknessPromptsText;

    [TextArea]
    public List<string> positiveReactionsText;

    [TextArea]
    public List<string> negativeReationsText;

    [TextArea]
    public List<string> missionStartPromptsText;

    [TextArea]
    public List<string> missionFailPromptsText;

    [TextArea]
    public List<string> missionSuceedPromptsText;

}


