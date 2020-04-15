using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    float thrust = 10f;
    float g = 10f;
    float rad = 15 * Mathf.Deg2Rad;

    Vector3 acc;
    Vector3 vel;
    Vector3 pos;
    Vector3 i, j, k;
    Vector3 zero = new Vector3(0f, 0f, 0f);
    Vector3 grav;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.up = new Vector3(0f, Mathf.Cos(rad), -1 * Mathf.Sin(rad));
        transform.forward = -1 * (new Vector3(0f, Mathf.Sin(rad), Mathf.Cos(rad)));
        transform.Translate(0f, 5f, -100f, Space.Self);

        grav = new Vector3(0f, -g, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        acc = Vector3.Dot(transform.forward, grav) * transform.forward;
        vel += acc * Time.deltaTime;
        acc = zero;

        if (Input.GetKey("w")) // Move forward
        {
            acc = thrust * transform.forward;
            vel += acc * Time.deltaTime;
        }

        if (Input.GetKey("s")) // Brakes
        {
            acc = -thrust * vel.normalized;
            if (vel.magnitude <= thrust * Time.deltaTime)
            {
                vel = zero;
                acc = zero;
            }
            else
            {
                vel += acc * Time.deltaTime;
            }
        }

        if (Input.GetKey("a")) // Turn left
        {
            transform.Rotate(0f, -1f, 0f, Space.Self);
            vel = vel.magnitude * transform.forward;
        }

        if (Input.GetKey("d")) // Turn right
        {
            transform.Rotate(0f, 1f, 0f, Space.Self);
            vel = vel.magnitude * transform.forward;
        }

        pos = vel * Time.deltaTime;
        transform.position += pos;
    }
}
