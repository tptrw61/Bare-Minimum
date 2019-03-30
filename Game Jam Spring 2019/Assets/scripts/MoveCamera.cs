using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float margin = 0.05f;
    public float leftBound = 0;
    public float rightBound = 0;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float normalizedMouseX = Input.mousePosition.x / Screen.width;

        //movement left
        if (transform.position.x < leftBound)
        {
            if(normalizedMouseX > margin)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0,0); // move on +X axis
            }
        }

        //movement right
        if (transform.position.x > rightBound)
        {
            if (normalizedMouseX < 1-margin)
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); // move on +X axis
            }
        }
    }
}
