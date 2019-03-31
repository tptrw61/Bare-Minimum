using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Computer : MonoBehaviour
{
    public BoxCollider2D box;
    public DialogueRunner run;
    private int count =0;
    // Start is called before the first frame update
    // Update is called once per frame
    private void OnMouseDown()
    {
        //if (count < (run.sourceText.Length)) count++;
        run.StartDialogue();
    }
}
