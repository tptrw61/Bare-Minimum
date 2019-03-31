using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ComputerInteract : MonoBehaviour
{

    public DialogueRunner run;
    //private int count =0;
    public MoveBoss boss;
    public fax_interact fax;
    public AudioSource beep;

    // Start is called before the first frame update
    void Start()
    {
        beep = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void OnMouseDown()
    {
        beep.Play();
        fax.working = false;
        float x = Random.Range(0.0f, 5.0f);
        if( x < 3.0f)
        {
            boss.StartCoroutine(boss.TimerSound(boss.time));
        }
        run.StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
