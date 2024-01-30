using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float speed = 1;
    [SerializeField, Range(0, 40)] float maxDistance = 5;
    float dash = 2;
    void Update()
    {

        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        //dash multiplier
        if (Input.GetKey(KeyCode.LeftShift))
        {
            force *= dash;
        }

        transform.localPosition += force;

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
    }
}
