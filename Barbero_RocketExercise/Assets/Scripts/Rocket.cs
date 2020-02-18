using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    float v = 100f;
    float theta = Mathf.Deg2Rad * 60f;
    float h = 0.22f;
    float g = 32f;
    float x, y, z;
    float tT = 0f;
    float stT = 1.0f;

    Vector3 acc;
    Vector3 vel;
    Vector3 pos;
    bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        tT = 0.0f;
        acc = new Vector3(0f, -g, 0f); //constant
        vel = new Vector3(v * Mathf.Cos(theta), v * Mathf.Sin(theta), 0f);  //initial velocity

        x = -8.5f;  //initial positions
        y = h;
        z = 0f;

        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            launched = !launched;

        if (launched)
        {
            tT += Time.deltaTime;
            x = v * Mathf.Cos(theta) * (stT * tT);
            y = h + v * Mathf.Sin(theta) * (stT * tT) - 0.5f * g * (stT * tT) * (stT * tT);
            pos = new Vector3(x, y, z);
        }
        else
        {
            tT = 0.0f;
            x = -8.5f;  //initial positions
            y = h;
            z = 0f;
            pos = new Vector3(x, y, z);
        }

        transform.position = pos;
    }
}
