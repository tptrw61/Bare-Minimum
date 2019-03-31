using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio_interrract : MonoBehaviour
{
    public AudioSource music;
    public AudioSource office;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        on = false;
    }

    void OnMouseDown()
    {
        if (!on)
        {
            music.Play();
            office.Stop();
            on = true;
        }
        else
        {
            music.Stop();
            office.Play();
            on = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
