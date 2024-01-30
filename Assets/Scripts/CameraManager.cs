using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera thirdPersonCamera;
    [SerializeField] Camera isoCamera;
    [SerializeField] Orbit cameraOrbit;
    [SerializeField] Pan pan;
    [SerializeField] GameObject player;
    [SerializeField] bool xLock = false;
    [SerializeField] bool yLock = false;
    [SerializeField] bool zLock = false;
    [SerializeField] bool oneTime = false;

    [SerializeField] Material skyboxUnderside;


    public void ShowIsoCamera()
    {
        isoCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        isoCamera.GetComponent<AudioListener>().enabled = true;
        thirdPersonCamera.GetComponent<AudioListener>().enabled = false;
        pan.allowedPanning = true;

        cameraOrbit.allowedRotation = false;

        player.GetComponent<PhysicsCharacterController>().isoMove = true;

    }
    public void ShowThirdPersonCamera()
    {
        pan.allowedPanning = false;

        isoCamera.enabled = false;
        thirdPersonCamera.enabled = true;

        isoCamera.GetComponent<AudioListener>().enabled = false; 
        thirdPersonCamera.GetComponent<AudioListener>().enabled = true; 

        //thirdPersonCamera.transform.position = Vector3.Lerp(isoCamera.transform.position, thirdPersonCamera.transform.position, Time.deltaTime);

        //thirdPersonCamera.transform.rotation = isoCamera.transform.rotation;
        cameraOrbit.allowedRotation = true;

        player.GetComponent<PhysicsCharacterController>().isoMove = false;

        RenderSettings.skybox = skyboxUnderside;
    }

    private void AxisReset()
    {
        Rigidbody m_RigidBody = player.GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.None;
    }
    private void XLock()
    {
        Rigidbody m_RigidBody = player.GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.FreezePositionX;
    }
    private void YLock()
    {
        Rigidbody m_RigidBody = player.GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.FreezePositionY;
    }
    private void ZLock()
    {
        Rigidbody m_RigidBody = player.GetComponent<Rigidbody>();

        m_RigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isoCamera.enabled) { ShowThirdPersonCamera(); }
        else { ShowIsoCamera(); }

        AxisReset();
        if(xLock == true) XLock();
        if(yLock == true) YLock();
        if(zLock == true) ZLock();

        if (oneTime) Destroy(gameObject);
    }
}
