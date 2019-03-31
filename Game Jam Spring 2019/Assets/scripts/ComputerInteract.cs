using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Yarn.Unity;

public class ComputerInteract : MonoBehaviour
{


public class Computer : MonoBehaviour
{
    //public BoxCollider2D box;
   // public DialogueRunner run;
    private int count =0;
    // Start is called before the first frame update
    // Update is called once per frame
    void OnMouseDown()
    {
                Debug.Log("touched the computer");
                
        //run.StartDialogue();
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
