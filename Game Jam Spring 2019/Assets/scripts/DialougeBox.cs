using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Show()
    {
        this.GetComponent<Renderer>().enabled = true;
    }

    void Hide()
    {
        this.GetComponent<Renderer>().enabled = false;
    }
}
