using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    float v = 50f;
    float theta = Mathf.Deg2Rad * 60f;
    float h = 4.5f;
    float g = 32f;
    float thrust = 64f;
    float x, y, z, force;
    float tT = 0f;
    float stT = 0.1f;

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

        x = 0f;  //initial positions
        y = h;
        z = 0f;

        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            launched = !launched;
            force = g - thrust;
        }

        if (launched)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                force = g;

            tT += Time.deltaTime;
            x = v * Mathf.Cos(theta) * (stT * tT);
            y = h + v * Mathf.Sin(theta) * (stT * tT) - 0.5f * force * (stT * tT) * (stT * tT);
            pos = new Vector3(x, y, z);
        }
        else
        {
            tT = 0.0f;
            x = 0f;  //initial positions
            y = h;
            z = 0f;
            pos = new Vector3(x, y, z);
        }
        

        transform.position = pos;
    }
}
