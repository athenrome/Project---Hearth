using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {


    Vector3 camPos;
    float posX;
    float posY;

    public int woodID;



    public bool burning;

    bool inFirepit;

    public bool selected;

    public float burnTime; //time it takes for a single piece of fuel to be consumed
    float currBurnTime;

    

    // Use this for initialization
    void Start()
    {
        
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

    //START FIREPIT
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<FirePit>() == true)//if the colliding object is the fire pit
        {
            FirePit pit = col.gameObject.GetComponent<FirePit>();

            Debug.Log("Entered pit");

            pit.AddWood(this);

            GameObject.Destroy(this.gameObject);

            
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Exited pit");
    }
    //END FIREPIT





    //START WOOD DRAGGING
    void OnMouseDown()
    {
        camPos = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - camPos.x;
        posY = Input.mousePosition.y - camPos.y;//1 - camPos.y;



        Debug.Log("Selected Log");

    }



    void OnMouseDrag()
    {
        //Vector3 currPos = new Vector3(Input.mousePosition.x - posX, 5, camPos.z);
        Vector3 currPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, camPos.z);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(currPos);


        transform.position = new Vector3(worldPos.x, worldPos.y, 0);

    }
    //END WOOD DRAGGING
}
