using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {

    Director director;

    public bool burning;

    bool inFirepit;

    public bool selected;

    public float burnTime; //time it takes for a single piece of fuel to be consumed
    float currBurnTime;

    public void BurnWood()
    {
        currBurnTime -= Time.deltaTime;

        if (currBurnTime <= 0)
        {
            burning = false;
        }
    }

    void DragWood()
    {
        this.transform.position = director.mousePosition;
    }

    // Use this for initialization
    void Start()
    {
        director = FindObjectOfType<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selected == true)
        {
            DragWood();
        }
    }
}
