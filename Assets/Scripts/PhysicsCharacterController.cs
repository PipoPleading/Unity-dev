using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField][Range(0, 10)]float maxForce;
    [SerializeField][Range(0, 10)]float jumpForce = 5;
    Vector3 force = Vector3.zero;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");


        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.blue);


        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);

        force = yrotation * direction * maxForce;

        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
