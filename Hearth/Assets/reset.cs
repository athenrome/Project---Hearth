using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CallReset();
	}

    void CallReset()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
