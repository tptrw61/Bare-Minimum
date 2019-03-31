using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterStamina : MonoBehaviour
{
    public GameObject myCamera;
    public float distance = 5.0f;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = myCamera.transform.rotation;
        Vector3 newposition = myCamera.transform.position + (rotation * Vector3.forward * distance) + (Vector3.up * 3.5f) + (Vector3.right * 7);
        this.transform.position = Vector3.Lerp(transform.position, newposition, Time.deltaTime * speed);
    }
}
