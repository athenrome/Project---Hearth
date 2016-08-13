using UnityEngine;
using System.Collections;

public class GameFloor : MonoBehaviour
{
    public WoodPile pile;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Wood>() == true)
        {
            pile.woodCount--;
            pile.AddWood(1);
            GameObject.Destroy(collision.gameObject);
        }
    }
}

