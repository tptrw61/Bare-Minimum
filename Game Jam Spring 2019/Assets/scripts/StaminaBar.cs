using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{

    public Sprite[] sprites;
    private SpriteRenderer sr;

    Stamina stamina;

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
        return 0;
    }
}
