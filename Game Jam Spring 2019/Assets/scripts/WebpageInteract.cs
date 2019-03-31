using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebpageInteract : MonoBehaviour
{
    private Vector3 targetpos;
    public float distance;
    public AudioSource beep;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.down * distance;
        Hide();
    }

    public void Show()
    {
        this.targetpos = new Vector3(-9.5f, -.04f, 0f);

    }

    void OnMouseDown()
    {
        beep.Play();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, Time.deltaTime * speed);
    }

    public void Hide()
    {
        this.targetpos = new Vector3(-9.5f, -9f, 0f);
    }
}
