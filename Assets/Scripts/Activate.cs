using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] PlatformMove move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            move._isMoving = true;
        }
        Destroy(gameObject);
    }
}
