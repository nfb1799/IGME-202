using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    float rad = 15 * Mathf.Deg2Rad;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.up = new Vector3(0f, Mathf.Cos(rad), -1 * Mathf.Sin(rad));
        transform.forward = -1*(new Vector3(0f, Mathf.Sin(rad), Mathf.Cos(rad)));
        transform.Translate(0f, 5f, -100f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
