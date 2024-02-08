using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerKinematicController : MonoBehaviour, IDamagable
{
    [SerializeField, Range(0, 100)] float speed = 1;
    [SerializeField, Range(0, 40)] float maxDistance = 5;
    [SerializeField, Range(0, 250)] float health = 5;
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

        //erronious, clamps position too hard seemingly?
        transform.localPosition += force;

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
    }
    public void ApplyDamage(float damage)
    {
        health -= damage;   
    }

    public void barrelRoll()
    {
        //set invincibility to true on a timer

        //rotate about Z for 360 degrees

        //toggle outline c
    }
}
