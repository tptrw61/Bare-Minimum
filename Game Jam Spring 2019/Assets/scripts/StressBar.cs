using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBar : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[4];
    private SpriteRenderer sr;

    Stamina stamina;

    // Start is called before the first frame update
    void Start()
    {
        stamina = this.gameObject.GetComponent<Stamina>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = sprites[stamina.stressCurrent];
    }
}
