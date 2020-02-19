using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    float v = 5f;
    float theta = Mathf.Deg2Rad * 60f;
    float h = 4.5f;
    float g = 3.2f;
    float t = 6.4f;
    float x, y, z;
    float tT = 0f;
    float stT = 0.01f;

    Vector3 acc;
    Vector3 thr;
    Vector3 vel;
    Vector3 pos;
    bool launched = false;
    bool countdown = false;

    // Start is called before the first frame update
    void Start()
    {
        tT = 0.0f;
        acc = new Vector3(0f, -g, 0f); //constant
        vel = new Vector3(v * Mathf.Cos(theta), v * Mathf.Sin(theta), 0f);  //initial velocity
        thr = new Vector3(t * Mathf.Cos(theta), t * Mathf.Sin(theta), 0f); //initial thrust
        acc = acc + thr;

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
            countdown = !countdown;
        }

        if(launched && countdown)
        {
            tT += Time.deltaTime;
            if(tT > 3f)
            {
                tT = 0f;
                countdown = !countdown;
            }
        }
        else if (launched && !countdown)
        {
            tT += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Alpha1))
                acc = new Vector3(0f, -g, 0f);
        }
        else
        {
            tT = 0.0f;
            x = 0f;  //initial positions
            y = h;
            z = 0f;
            vel = new Vector3(v * Mathf.Cos(theta), v * Mathf.Sin(theta), 0f);
            pos = new Vector3(x, y, z);
        }

        if (!countdown)
        {
            vel = vel + stT * tT * acc;
            pos = pos + stT * tT * vel;
            transform.position = pos;
        }
        
    }
}
