using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    Vector3 mouseWorldPos;
    float theta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            RotateToMouse();
    }

    void RotateToMouse()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        theta = 180.0f + (Mathf.Atan2(mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(0, 0, theta);
    }
}
