using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coffee_interact : MonoBehaviour
{
    public Stamina stamina;
    public AudioSource sip;

    public float sipTimeout = 1f;
    private float sipTimePassed;

    // Start is called before the first frame update
    void Start()
    {
        sipTimePassed = 0;
        sip = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (sipTimePassed >= sipTimeout && stamina.computer.noDialogue)
        {
            stamina.restoreStamina(stamina.staminaMax / 8f);
            sipTimePassed = 0;
            sip.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina.computer.noDialogue)
            sipTimePassed += Time.deltaTime;
    }
}
