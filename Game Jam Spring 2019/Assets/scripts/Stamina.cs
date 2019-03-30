using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public bool DEBUG = true;

    private Vector3 prevPos;

    public float staminaDrain = .125f, stressDrain = 1f;

    public float staminaMax = 3000f;
    public float staminaCurrent;

    public int stressMax = 3;
    public int stressCurrent;
    
    public bool tired = false;
    public bool stressed = false;

    // Start is called before the first frame update
    void Start()
    {
        staminaCurrent = staminaMax;
        stressCurrent = 0;

        prevPos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = Input.mousePosition;
        staminaCurrent -= (Vector3.Distance(curPos, prevPos)*staminaDrain) + (stressDrain*Time.deltaTime*stressCurrent);
        prevPos = curPos;
        //DEBUG ONLY
        if (DEBUG)
        {
            if (Input.GetMouseButtonDown(0))
                    increaseStress();
            if (Input.GetMouseButtonDown(1))
                stressCurrent--;
            if (Input.GetMouseButtonDown(2))
            {
                staminaCurrent = staminaMax;
                stressCurrent = 0;
            }
        }
        //reporting to console
        if (stressCurrent < 3)
            stressed = false;
        if (staminaCurrent >= 0)
            tired = false;
        if(stressCurrent > stressMax && !stressed)
        {
            stressed = true;
            Debug.Log("Stressed Out");
        }
        if (staminaCurrent < 0 && !tired)
        {
            tired = true;
            Debug.Log("Out Of Stamina");
        }
    }

    public bool increaseStress()
    {
        stressCurrent++;
        return stressCurrent > stressMax;
    }
    public bool isStressedOut()
    {
        return stressCurrent > stressMax;
    }
}
