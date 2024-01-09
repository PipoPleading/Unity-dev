using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Vector3 CamPos;

    [Header("Camera Stats")]
    public float CamSpeed;
    // Start is called before the first frame update
    void Start()
    {
        CamPos = this.transform.position;
        CamSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            CamPos.y += CamSpeed / 10;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            CamPos.y -= CamSpeed / 10;

        }
        if (Input.GetKey(KeyCode.A))
        {
            CamPos.x -= CamSpeed / 10;

        }
        if (Input.GetKey(KeyCode.D))
        {
            CamPos.x += CamSpeed / 10;

        }

        this.transform.position = CamPos;
    }
}
