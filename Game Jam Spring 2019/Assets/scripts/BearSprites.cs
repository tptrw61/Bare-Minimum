using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSprites : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[3];
    private SpriteRenderer sr;

    public Stamina stamina;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = sprites[getSpriteIndex()];
    }

    private int getSpriteIndex()
    {
        switch (stamina.stressCurrent)
        {
            case 1:
            case 2:
                return 1;
            case 3:
            case 4:
                return 2;
            default:
                return 0;
        }
    }
}
