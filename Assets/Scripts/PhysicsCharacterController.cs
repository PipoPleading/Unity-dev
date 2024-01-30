using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField][Range(0, 10)]float maxForce;
    [SerializeField][Range(0, 10)]float jumpForce = 5;
    [SerializeField][Range(0, 20)]float dashForce = 5;
    Vector3 force = Vector3.zero;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField][Range(1, 100)] float rayLength = 10;
    [SerializeField] LayerMask groundLayerMask;
    [Header("Additional Movement")]
    [SerializeField] public bool isoMove = false;
    [SerializeField] bool grounded = false;
    [SerializeField] public bool dashable = false;
    [SerializeField] public bool dead = false;
    Vector3 direction = Vector3.zero;
    Quaternion yrotation;
    [Header("Effects")]
    [SerializeField] GameObject jumpPrefab;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] GameObject dashPrefab;
    [SerializeField] AudioSource dashSound;

    public float targetTime = 60.0f;

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(isoMove) Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!dead)
        {

            if (!isoMove)
            {
                ThirdPersonMove(ref direction);
            }
            else
            {
                direction.x = Input.GetAxis("Horizontal");
                force = direction * maxForce;

            }

            //force ray
            //Debug.DrawRay(transform.position, direction, Color.magenta);
            Debug.DrawRay(transform.position, direction * maxForce, Color.red);

            CheckGround();

            Jump();

            Dash();

            targetTime -= Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;

            jumpSound.Play();
            //Instantiate(jumpPrefab, transform.position, Quaternion.identity);
            Instantiate(dashPrefab, transform.position, Quaternion.identity);

        }

    }
    
    private void Dash()
    {
        //Fire3 is either left shift or mouse 3
        if (Input.GetButtonDown("Fire3") && dashable) 
        {
            //force should set you slightly off the ground, and shoot you forward
            rb.AddForce(yrotation * direction * dashForce, ForceMode.Impulse);
            dashable = false;

            //Debug.Log("Current dash: " + (yrotation * direction * dashForce) );
            dashSound.Play();

            Instantiate(dashPrefab, transform.position, Quaternion.identity);

            
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
    }

    private void CheckGround()
    {
        //Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.cyan);

        grounded = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
        
        if(grounded) { dashable = true; }
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
    }

    public void ThirdPersonMove(ref Vector3 direction)
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);

        force = yrotation * direction * maxForce;

    }
}
