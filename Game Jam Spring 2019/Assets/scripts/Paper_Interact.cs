using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper_Interact : MonoBehaviour
{
    private Vector3 targetpos;
    public float distance;
    public AudioSource stamp;

    //Image m_Image;
   // public Sprite stamped;
    //public Sprite clean;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.down * distance;
       // m_Image = clean;
        Hide();
        Show();
    }

    public void Show()
    {
        //m_Image = clean;
        this.targetpos = new Vector3(-2.9f, .02f, 0f);

    }

    void OnMouseDown()
    {
        stamp.Play();
        //m_Image.sprite = m_Sprite;
        Hide();
    }

        // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, Time.deltaTime * speed);
    }

    public void Hide()
    {
        this.targetpos = new Vector3(-2.9f, -10f, 0f);
    }
}
