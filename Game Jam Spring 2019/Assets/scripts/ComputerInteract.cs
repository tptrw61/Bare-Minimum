using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour
{

   public Canvas canvasObject;

    public AudioSource beep;

    // Start is called before the first frame update
    void Start()
    {
        beep = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void OnMouseDown()
    {
        beep.Play();
        canvasObject.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
