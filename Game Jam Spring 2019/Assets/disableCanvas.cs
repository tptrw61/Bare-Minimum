using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas c;
    void Start()
    {
        c= GetComponent<Canvas>();
    }
    void DisableCanvas() {
        c.enabled = false;
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
