using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fax_interact : MonoBehaviour
{
    public Animator printer;
    public AudioSource print;
    public bool working;
    public Paper_Interact paper;

    // Start is called before the first frame update
    void Start()
    {
        working = false;
    }

    void OnMouseDown()
    {
        working = true;
        print.Play();
        printer.Play("");
        paper.Show();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
