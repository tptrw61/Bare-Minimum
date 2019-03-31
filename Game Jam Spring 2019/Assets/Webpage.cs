using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webpage : MonoBehaviour
{
	public GameObject webpage;
	//public Button chatRoom;
	//public Button Mewtube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableCanvas(){
    	webpage.SetActive(false);
    }
}
