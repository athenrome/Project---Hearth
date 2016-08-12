using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public float scaleX = 0.6485662f;
    public float scaleY = 1.040526f;
    public float scaleZ = 0.9673969f;
    public float scaleMod;

    // Use this for initialization
    [ContextMenu("DoIt")]
    void RotateAndScale ()
    {
        scaleMod = Random.Range(0.5f, 1.0f);
        var lsx = scaleX + scaleMod;
        var lsy = scaleY + scaleMod;
        var lsz = scaleZ + scaleMod;
        transform.localScale = new Vector3(lsx, lsy, lsz);
        transform.eulerAngles = new Vector3(-90.0f, Random.Range(0.0f, 360.0f), 0.0f);
        //ScaleTree();

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this.gameObject);
#endif
    }

}
