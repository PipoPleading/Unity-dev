using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketMove : MonoBehaviour
{
    Rigidbody rb;
    Boolean bucketPos = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bucketPos = !bucketPos;
        }

        if(bucketPos == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * 500);
        }
    }
}
