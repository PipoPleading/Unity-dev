using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    [SerializeField][Range(0.1f, 50.0f)] float distance = 10;
    [SerializeField][Range(0.1f, 50.0f)] float offset = 10;
    [SerializeField] GameObject player;
    public bool allowedPanning = true;

    public void Start()
    {

    }

    void Update()
    {
        if (allowedPanning) 
        {
            transform.position = player.transform.position - (Vector3.forward * distance) + (Vector3.up * offset);
        }
/*        Vector3 inputDir = new Vector3(0, 0, 0);
        if (allowedPanning)
        {

            if (Input.GetMouseButtonDown(1))
            {
                panActive = true;
                lastMousePosition = Input.mouseScrollDelta;

            }
            if (Input.GetMouseButtonUp(1))
            {
                panActive = false;
            }
        }

        if (panActive) 
        {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

            Debug.Log(mouseMovementDelta);

            inputDir.x = mouseMovementDelta.x * sensitivity;
            inputDir.y = mouseMovementDelta.y * sensitivity;

            lastMousePosition = Input.mousePosition;
        }

        Vector3 moveDir = transform.up * inputDir.y + transform.right * inputDir.x;
        transform.position += moveDir * sensitivity * Time.deltaTime;*/

    }

}
