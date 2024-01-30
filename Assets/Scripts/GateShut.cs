using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateShut : MonoBehaviour
{
    public bool _isMoving = false;
    Vector3 scale = Vector3.one * 4;

    Vector3 origin = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            transform.localScale.Scale(scale);
        }
    }
}
