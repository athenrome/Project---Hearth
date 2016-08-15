using UnityEngine;
using System.Collections;

public class PlayerVisibilityController : MonoBehaviour {

    private Renderer[] myRenderers;
    public float desiredVisibility = 1;
    static float distanceFromLightScale = 0.5f, percentFromLightToAppear = 1, percentFromLightToDis = 0.8f;

    public float timeTillAppear, timeTillDisappear;
    private float counter;

    public float fadeSpeed = 1;

    // Use this for initialization
    void Start ()
    {
        myRenderers = gameObject.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < myRenderers.Length; i++)
        {
            var currcol = myRenderers[i].material.color;
            currcol.a = Mathf.Lerp(currcol.a, desiredVisibility, Time.deltaTime * fadeSpeed);
            myRenderers[i].material.color = currcol;    
        }

        //what state am i in
        HandleUpdatingVisState();

       
    }

    void HandleUpdatingVisState()
    {
        var diff = (Hack_Flame.inst.gameObject.transform.position - transform.position);
        var diffLen = diff.magnitude;
        float minIntensityToAppear = diffLen * distanceFromLightScale * percentFromLightToAppear;
        float minIntensityToDisappear = diffLen * distanceFromLightScale * percentFromLightToDis;

        //if not visible
        if (desiredVisibility <= 0f)
        {
            //is value above tolerance
            if (Hack_Flame.inst.intensity > minIntensityToAppear)
            {
                //increase counter
                counter += Time.deltaTime;
                //if counter above time limit then go vis
                if (counter >= timeTillAppear)
                    desiredVisibility = 1;
            }
            else
            {
                counter = 0;
            }
        }
        else
        {
            if (Hack_Flame.inst.intensity < minIntensityToDisappear)
            {
                counter += Time.deltaTime;

                if (counter >= timeTillDisappear)
                    desiredVisibility = 0;
            }
            else
            {
                counter = 0;
            }
        }
    }
}
