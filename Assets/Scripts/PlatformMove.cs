using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public bool _isMoving = false;
    [SerializeField] float rate = 1;
    [SerializeField] float amplitude = 1f;

    float time;
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
            time += Time.deltaTime * rate;
            float wave = Mathf.Sin(time) * amplitude;

            transform.position = origin + (Vector3.up * wave);
        }
    }
}
