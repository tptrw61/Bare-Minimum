using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coffee_interact : MonoBehaviour
{
    public Stamina stamina;
    public AudioSource sip;

    // Start is called before the first frame update
    void Start()
    {
        sip = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        stamina.restoreStamina(450f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
