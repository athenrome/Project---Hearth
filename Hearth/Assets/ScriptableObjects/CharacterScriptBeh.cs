using UnityEngine;
using System.Collections;

public class CharacterScriptBeh : MonoBehaviour {

    public CharacterScriptObj test;
    public void OnEnable()
    {
        // instantiate if needed
        if (test == null)
            test = ScriptableObject.CreateInstance<CharacterScriptObj>();
    }
}
