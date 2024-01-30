using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] bool xRotate = false;
    [SerializeField] bool yRotate = false;
    [SerializeField] bool zRotate = false;
    [SerializeField][Range(-360, 360)] float angle;
    void Update()
    {
        if(xRotate)transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.right);
        if(yRotate)transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);
        if(zRotate)transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.forward);
    }
}
