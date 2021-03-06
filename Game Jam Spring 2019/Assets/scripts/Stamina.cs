﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stamina : MonoBehaviour
{
    public ComputerInteract computer;
    public fax_interact fax;

    public bool DEBUG = false;
    public bool USE_GAME_OVER = true;

    private Vector3 prevPos;

    public float staminaDrain = 1f, stressDrain = 5f;

    public float staminaMax = 9000f;
    public float staminaCurrent;

    public int stressMax = 3;
    public int stressCurrent;

    public float workPenalty = 0;
    public float wpRate = .25f;
    public float wpInc = 1f;
    public float wpDec = 3f;
    
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
        if (fax.working && computer.noDialogue)
        {
            workPenalty += Time.deltaTime * wpRate * wpInc;
        } else if (computer.noDialogue)
        {
            workPenalty -= Time.deltaTime * wpRate * wpDec;
            if (workPenalty < 0)
                workPenalty = 0;
        }

        Vector3 curPos = Input.mousePosition;
        if (computer.noDialogue)
            staminaCurrent -= (Vector3.Distance(curPos, prevPos)*staminaDrain) + (stressDrain*Time.deltaTime*stressCurrent) + (workPenalty*Time.deltaTime);
        prevPos = curPos;
        //DEBUG ONLY
        if (DEBUG)
        {
            if (Input.GetKeyDown(KeyCode.I))
                increaseStress();
            if (Input.GetKeyDown(KeyCode.O))
                decreaseStress();
            if (Input.GetKeyDown(KeyCode.P))
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
        if (stressCurrent > stressMax && !stressed)
        {
            stressed = true;
            Debug.Log("Stressed Out");
        }
        if (staminaCurrent < 0 && !tired)
        {
            tired = true;
            Debug.Log("Out Of Stamina");
        }
        if ((staminaCurrent < 0 || stressed) && USE_GAME_OVER)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
    public void useStamina(float used)
    {
        staminaCurrent -= used;
        if (staminaCurrent < 0)
            staminaCurrent = 0;
    }
    public void restoreStamina(float restored)
    {
        staminaCurrent += restored;
        if (staminaCurrent > staminaMax)
            staminaCurrent = staminaMax;
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
