using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera north, south, east, west, over;
    private Camera current;

    // Start is called before the first frame update
    void Start()
    {
        north.enabled = true;
        current = north;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1")) //switch to north cam
        {
            current.enabled = false;
            north.enabled = true;
            current = north;
        }
        if (Input.GetKey("2")) //switch to east cam
        {
            current.enabled = false;
            east.enabled = true;
            current = east;
        }
        if (Input.GetKey("3")) //switch to south cam
        {
            current.enabled = false;
            south.enabled = true;
            current = south;
        }
        if (Input.GetKey("4")) //switch to west cam
        {
            current.enabled = false;
            west.enabled = true;
            current = west;
        }
        if (Input.GetKey("5")) //switch to overhead cam
        {
            current.enabled = false;
            over.enabled = true;
            current = over;
        }

    }
}
