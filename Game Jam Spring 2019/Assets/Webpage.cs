using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using Yarn.Unity;

public class Webpage : MonoBehaviour
{
	public GameObject webpage;
	public Button chatRoom;
	public Button mewtube;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        //mewtube.onClick.AddListener(webpage);
       //chatRoom.onClick.AddListener(webpage);
       exitButton.onClick.AddListener(DisableCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableCanvas(){
    	webpage.SetActive(false);
    }
}
