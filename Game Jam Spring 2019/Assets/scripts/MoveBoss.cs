using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    private Vector3 targetpos;
    public float distance;

    public float speed;
    private bool showing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.left * distance;
    }

    public void Show()
    {
        this.targetpos = new Vector3(8.6f, .5f, 0f);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, Time.deltaTime*speed);
        if(showing && Vector3.Distance(transform.position, targetpos)<= 0.1f)
        {
            showDialogue();
        }
    }

    private void showDialogue()
    {

    }

    public void Hide()
    {
        this.targetpos = new Vector3(2.6f, .5f, 0f);
    }
}