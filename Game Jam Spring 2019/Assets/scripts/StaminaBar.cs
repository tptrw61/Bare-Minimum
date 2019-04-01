using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[8];
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
        //use this to figure out the correct sprite's index
        int buffer = (int)(stamina.staminaMax / 16f);
        int value = (int)((stamina.staminaCurrent + buffer) / (stamina.staminaMax / 8f));
        if (value < 0)
            value = 0;
        if (value > 7)
            value = 7;
        return value;
    }
}
