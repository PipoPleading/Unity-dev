using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinematicController : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float speed = 1;
    [SerializeField, Range(0, 100)] float rotationAngle;
    [SerializeField, Range(0, 40)] float maxDistance = 5;
    [SerializeField][Range(-360, 360)] float barrelAngle;

    [SerializeField] Material outline;
    float dash = 2;
    float followerDash = 1.2f;
    float dashTime = 10;
    float brCooldownTime = 10;


    void Update()
    {

        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        //dash multiplier
        if (Input.GetKey(KeyCode.E))
        {
            force *= dash;
            dashTime *= dash;

        }

        //erronious, clamps position too hard seemingly?
        transform.localPosition += force;

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);

        //barrel roll bool (timer?)

        Quaternion qyaw = Quaternion.AngleAxis(direction.x * rotationAngle, Vector3.up);
        Quaternion qroll = Quaternion.AngleAxis(-direction.x * rotationAngle * 3, Vector3.forward);
        Quaternion qpitch = Quaternion.AngleAxis(-(direction.y) * rotationAngle, Vector3.right);

        Quaternion rotation = qyaw * qpitch * qroll;


        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, dashTime * Time.deltaTime);
    }


    public void barrelRoll()
    {


        //set invincibility to true on a timer

        //rotate about Z for 360 degrees
        transform.rotation *= Quaternion.AngleAxis(barrelAngle * Time.deltaTime, Vector3.forward);

        //cel color change
/*        outline.color = color*/
    }

    IEnumerator BarrelRollCR()
    {
        if (Input.GetKey(KeyCode.Q))
        {

            yield return new WaitForSeconds(brCooldownTime);

            barrelRoll();
        }
    }
}
