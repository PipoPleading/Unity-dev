using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] public bool oneTime;
    // start position
    [SerializeField] private Camera _camera; 
    // modification of start position
    [SerializeField] private Vector3 tPosition; 
    private Vector3 ePosition; 


    [SerializeField] private float elapsedTime;
    [SerializeField] private float duration;

    private void OnTriggerEnter(Collider other)
    {
        //_camera.transform.position.x += tPosition.x;
    }

    // Move to the target end position.
    void Update()
    {
/*        elapsedTime += Time.deltaTime;
        float completionPercent = elapsedTime / elapsedTime;

        ePosition = Vector3.Lerp(_camera.transform.position, tPosition, completionPercent);
        _camera.transform.position = ePosition;*/
    }
}

    

