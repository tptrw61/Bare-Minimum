using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fax_interact : MonoBehaviour
{
    public Animator printer;
    public AudioSource print;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMouseDown()
    {
        print.Play();
        printer.Play("");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
