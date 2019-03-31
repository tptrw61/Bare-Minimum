using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ComputerInteract : MonoBehaviour
{

   public DialogueRunner run;
   //private int count =0;

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
        run.StartDialogue();
        beep.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
