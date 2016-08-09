using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public float scaleX = 0.6485662f;
    public float scaleY = 1.040526f;
    public float scaleZ = 0.9673969f;
    public float scaleMod;

    // Use this for initialization
    void Start ()
    {
        scaleMod = Random.Range(0.5f, 1.0f);
        scaleX += scaleMod;
        scaleY += scaleMod;
        scaleZ += scaleMod;
        ScaleTree();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void ScaleTree ()
    {
        transform.localScale=new Vector3(scaleX, scaleY, scaleZ);
        transform.eulerAngles = new Vector3(-90.0f, Random.Range(0.0f, 360.0f), 0.0f);
        //Bounds b = transform.GetComponent<Collider>().GetComponent<Bounds>();
        //float offset = b.min.z*scale;
        //Vector3 pos = transform.position;
        //pos.y = offset;
        //ransform.position = pos;

    }
}
