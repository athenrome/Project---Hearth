using UnityEngine;
using System.Collections;

public class PlayerVisibilityController : MonoBehaviour
{

    private Renderer[] myRenderers;
    public float desiredVisibility = 1;
    private float curVis;
    //light scale converts from world space to light intensity. 
    static float distanceFromLightScale = 0.5f, percentFromLightToAppear = 1, percentFromLightToDis = 0.8f;

    public float timeTillAppear, timeTillDisappear;
    private float counter;

    public float fadeSpeed = 1;

    public float timeTillTransition = 1;
    private float transitionCounter = 0;
    public GameObject enableWhenTrasitionComplete;
    public bool isTransitioning = false;

    public GameObject[] toggleActiveOnDisappear;

    // Use this for initialization
    void Start()
    {
        myRenderers = gameObject.GetComponentsInChildren<Renderer>();
        SetAllAlpha(desiredVisibility, true);
        curVis = desiredVisibility;
    }

    void OnEnable()
    {
        SetAllAlpha(desiredVisibility, true);
        curVis = desiredVisibility;
        isTransitioning = false;
        transitionCounter = 0;
        counter = 0;
    }



    // Update is called once per frame
    void Update()
    {
        curVis = Mathf.MoveTowards(curVis, desiredVisibility, Time.deltaTime * fadeSpeed); 
        SetAllAlpha(curVis, true);

        //what state am i in, be here or not or transition
        if (!isTransitioning)
        {
            HandleUpdatingVisState();

            if(curVis <= 0 && desiredVisibility <= 0)
            {
                for (int i = 0; i < toggleActiveOnDisappear.Length; i++)
                {
                    toggleActiveOnDisappear[i].SetActive(!toggleActiveOnDisappear[i].activeSelf);
                }
            }
        }
        else
        {
            if (curVis <= 0)
            {
                gameObject.SetActive(false);
                enableWhenTrasitionComplete.SetActive(true);
            }
        }

        //if we are here then it's time to see if we should transition to destination
        if (desiredVisibility >= 1 && enableWhenTrasitionComplete != null)
        {
            transitionCounter += Time.deltaTime;
            if(transitionCounter > timeTillTransition)
            {
                TriggerTransition();
            }
        }
        else
        {
            transitionCounter = 0;
        }

        if(curVis == 0)
        {

        }
    }

    void TriggerTransition()
    {
        isTransitioning = true;
        desiredVisibility = 0;
    }

    void SetAllAlpha(float target, bool overrideLerp = false)
    {
        if (myRenderers == null)
            return;

        for (int i = 0; i < myRenderers.Length; i++)
        {
            var matArray = myRenderers[i].materials;

            for (int j = 0; j < matArray.Length; j++)
            {
                var currcol = matArray[j].color;
                if (!overrideLerp)
                {
                    currcol.a = Mathf.MoveTowards(currcol.a, target, Time.deltaTime * fadeSpeed);
                }
                else
                {
                    currcol.a = target;
                }

                matArray[j].color = currcol;
            }

            myRenderers[i].materials = matArray;
        }
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
                {
                    desiredVisibility = 1;
                    counter = 0;
                }
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
                {
                    desiredVisibility = 0;
                    counter = 0;
                }
            }
            else
            {
                counter = 0;
            }
        }
    }
}
