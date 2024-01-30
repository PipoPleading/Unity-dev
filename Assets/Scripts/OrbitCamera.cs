using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField][Range(20, 90)] float defaultPitch = 40;
    [SerializeField][Range(2, 8)] float distance = 8;
    [SerializeField][Range(0.1f, 10.0f)] float sensitivity = 10;
    [SerializeField] public bool allowedRotation = false;

    float yaw = 0;
    float pitch = 0;

    public void Start()
    {
        pitch = defaultPitch;
    }

    void Update()
    {
        if (allowedRotation == true)
        {
            RotationEnabled();
        }

        //transform.SetPositionAndRotation((target.position + (rotation * Vector3.back * distance)), rotation);
    }

    public void RotationEnabled()
    {
        
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;

        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;

        //maple method
        transform.position = target.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }


}
