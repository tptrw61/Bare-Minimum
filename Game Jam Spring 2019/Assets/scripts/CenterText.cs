using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterText : MonoBehaviour
{
    public GameObject myCamera;
    public float distance = 5.0f;
    public float speed;

    void Update()
    {
        Quaternion rotation = myCamera.transform.rotation;
        Vector3 newposition = myCamera.transform.position + (rotation * Vector3.forward * distance) + (Vector3.down*3);
        this.transform.position = Vector3.Lerp(transform.position, newposition, Time.deltaTime*speed);
    }
}
