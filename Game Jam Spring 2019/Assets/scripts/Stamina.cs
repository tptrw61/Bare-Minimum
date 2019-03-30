using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public bool DEBUG = false;

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
            if (Input.GetKeyDown(KeyCode.Plus))
                    increaseStress();
            if (Input.GetKeyDown(KeyCode.Minus))
                stressCurrent--;
            if (Input.GetKeyDown(KeyCode.Asterisk))
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

    public void useStamina(float used)
    {
        staminaCurrent -= used;
    }
    public void restoreStamina(float restored)
    {
        staminaCurrent += restored;
    }

    public void increaseStress()
    {
        stressCurrent++;
        if (stressCurrent > 4)
            stressCurrent = 4;
    }
    public void decreaseStress()
    {
        stressCurrent--;
        if (stressCurrent < 0)
            stressCurrent = 0;
    }

    public bool looseByStress()
    {
        return stressCurrent > stressMax;
    }
    public bool looseByStamina()
    {
        return staminaCurrent <= 0;
    }
}
