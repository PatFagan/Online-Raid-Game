using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xRotation, yRotation, zRotation;

    void Update()
    {
        gameObject.transform.Rotate(xRotation, yRotation, zRotation, Space.Self); // rotate
    }
}