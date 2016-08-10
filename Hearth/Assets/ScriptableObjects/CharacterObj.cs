using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Character")]
public class CharacterObj : ScriptableObject
{
    public string characterName;
    public int effiecny;

    public GameObject characterModel;

    public List<DialogueStory> HopefulStorys;
    public List<DialogueStory> GhostStorys;

    public List<Dialogue> NeedWoodPrompts;
    public List<Dialogue> WoodArrivesPrompts;

    public List<Dialogue> LightDropPrompts;
    public List<Dialogue> LightBoostPrompts;

    public List<Dialogue> darknessPrompts;

    public List<Dialogue> DecreasedSanityPrompts;
    public List<Dialogue> IncreasedSanityPrompts;

    public List<Dialogue> PositiveReactions;
    public List<Dialogue> NegativeReations;
}


