using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ComputerInteract : MonoBehaviour
{
    //private int count =0;
    public Stamina stamina;
    public MoveBoss boss;
    public fax_interact fax;
    public AudioSource beep;
    public bool trigger;
    public bool trackTimeWorking;
    public bool noDialogue;         //false when dialogue is running
    public bool USE_BOSSTIME;
    public WebpageInteract page;
    public float startChance;
    public float deltaChance;
    public float checkTimeout;
    public float currentChance;
    public float chanceTime;
    public float timeToDestress = 30f;
    public float timeNotWorking;

    // Start is called before the first frame update
    void Start()
    {
        USE_BOSSTIME = false;
        currentChance = startChance = .05f;
        deltaChance = .025f;
        checkTimeout = 1.5f;
        timeToDestress = 30;
        beep = GetComponent<AudioSource>();
        trigger = false;
        trackTimeWorking = noDialogue = true;
        chanceTime = 0;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void OnMouseDown()
    {
        beep.Play();
        page.Show();
        //stamina.decreaseStress();
        fax.working = false;
        /*----------------------------------- this functionality was moved to update
        float x = Random.Range(0.0f, 3.0f);
        if( x < 2.5f && !trigger)
        {
            trigger = true;
            boss.StartCoroutine(boss.TimerSound(boss.time));
        }
        // */
    }

    // Update is called once per frame
    void Update()
    {
        //every 'checkTimout' seconds, it has a chance of moving the boss
        //on a failed attempt, the odds increasse by 'deltaChance'
        if (!fax.working)
            chanceTime += Time.deltaTime;
        else
            chanceTime = 0;
        if (!fax.working && trackTimeWorking && stamina.stressCurrent > 0 && noDialogue)
            timeNotWorking += Time.deltaTime;
        if (chanceTime >= checkTimeout && !fax.working && !trigger)
        {
            checkToMoveBoss();
            chanceTime = 0;
        }
        if (timeNotWorking >= timeToDestress && stamina.stressCurrent > 0)
        {
            timeNotWorking = 0;
            stamina.decreaseStress();
        }
    }

    private void checkToMoveBoss()
    {
        float p = Random.value;
        Debug.Log(p.ToString());
        if (p < currentChance)
        {
            trigger = true;
            currentChance = startChance;
            boss.StartCoroutine(boss.TimerSound(USE_BOSSTIME ? boss.time : 6f));
        } else
        {
            currentChance += deltaChance;
        }
    }
}
