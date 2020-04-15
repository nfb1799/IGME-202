using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    bool moving;
    float t;
    float rad;
    float theta;
    float slope;
    float x, z;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        t = Time.deltaTime;
        rad = 30f;
        theta = 1f;
        slope = Mathf.Sin(15f * Mathf.Deg2Rad) / Mathf.Cos(15f * Mathf.Deg2Rad);
        x = rad * Mathf.Cos(theta * t);
        z = rad * Mathf.Sin(theta * t);
        transform.position = new Vector3(x, slope * z, z);
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("0"))
        {
            moving = true;
            audioData.Play();
        }

        if (Input.GetKey("1"))
        { 
            moving = false;
            audioData.Stop();
        }

        if (moving)
            Loop();
    }

    void Loop()
    {
        t += Time.deltaTime;
        x = rad * Mathf.Cos(theta * t);
        z = rad * Mathf.Sin(theta * t);
        transform.position = new Vector3(x, slope * z, z);
    }
}
