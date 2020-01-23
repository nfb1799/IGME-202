using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
            transform.Rotate(0, 10.0f, 0, Space.Self);
        if (Input.GetKeyUp("y"))
            transform.Rotate(0, -10.0f, 0, Space.Self);

        if (Input.GetKeyDown("x"))
            transform.Rotate(10.0f, 0, 0, Space.Self);
        if (Input.GetKeyUp("x"))
            transform.Rotate(-10.0f, 0, 0, Space.Self);

        if (Input.GetKeyDown("z"))
            transform.Rotate(0, 0, 10.0f, Space.Self);
        if (Input.GetKeyUp("z"))
            transform.Rotate(0, 0, -10.0f, Space.Self);

        if (Input.GetKeyDown("r"))
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
