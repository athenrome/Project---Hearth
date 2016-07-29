using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {


    Vector3 camPos;
    float posX;
    float posY;



    public int woodID;

    Director director;

    public bool burning;

    bool inFirepit;

    public bool selected;

    public float burnTime; //time it takes for a single piece of fuel to be consumed
    float currBurnTime;

    

    // Use this for initialization
    void Start()
    {
        director = FindObjectOfType<Director>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BurnWood()
    {
        currBurnTime -= Time.deltaTime;

        if (currBurnTime <= 0)
        {
            burning = false;
        }
    }

    //START WOOD DRAGGING
    void OnMouseDown()
    {
        camPos = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - camPos.x;
        posY = Input.mousePosition.y - camPos.y;

    }

    void OnMouseDrag()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, camPos.z);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }
    //END WOOD DRAGGING
}
