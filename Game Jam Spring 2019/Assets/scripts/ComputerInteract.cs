using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ComputerInteract : MonoBehaviour
{
    //private int count =0;
    public MoveBoss boss;
    public fax_interact fax;
    public AudioSource beep;
    public bool trigger;
    public WebpageInteract page;

    // Start is called before the first frame update
    void Start()
    {
        beep = GetComponent<AudioSource>();
        trigger = false;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void OnMouseDown()
    {
        beep.Play();
        page.Show();
        fax.working = false;
        float x = Random.Range(0.0f, 3.0f);
        if( x < 2.5f && !trigger)
        {
            trigger = true;
            boss.StartCoroutine(boss.TimerSound(boss.time));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
