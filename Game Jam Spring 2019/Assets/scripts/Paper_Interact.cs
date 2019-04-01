using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper_Interact : MonoBehaviour
{
    private Vector3 targetpos;
    public float distance;
    public AudioSource stamp;

    private SpriteRenderer sr;
    public Sprite[] sprites = new Sprite[2];

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        this.transform.position = Vector3.down * distance;
        Hide();
    }

    public void Show()
    {
        sr.sprite = sprites[0];
        this.targetpos = new Vector3(-2.9f, .02f, 0f);

    }

    void OnMouseDown()
    {
        stamp.Play();
        sr.sprite = sprites[1];
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
