using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ScaleTree();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ScaleTree ()
    {
        float scale = Random.Range(0.7f, 2.0f);
        transform.localScale=new Vector3(scale, scale, scale);
        transform.eulerAngles = new Vector3(-90.0f, Random.Range(0.0f, 360.0f), 0.0f);
        Bounds b = transform.GetComponent<Collider>().GetComponent<Bounds>();
        float offset = b.min.z*scale;
       // Vector3 pos = transform.position;
        //pos.y = offset;
        //ransform.position = pos;

    }
}
