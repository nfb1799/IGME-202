using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(-15f, new Vector3(1f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
