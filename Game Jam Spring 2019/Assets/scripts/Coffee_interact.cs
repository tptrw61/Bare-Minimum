using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coffee_interact : MonoBehaviour
{
    public Stamina stamina;

    // Start is called before the first frame update
    void Start()
    {
        
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
