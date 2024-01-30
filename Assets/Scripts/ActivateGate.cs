using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGate : MonoBehaviour
{
    [SerializeField] GateShut move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            move._isMoving = true;
        }
        Destroy(gameObject);
    }
}
