using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERV_C : MonoBehaviour
{
    Vector3 pos;
    Vector3 vel;
    Vector3 acc;

    float speed;
    float x, y, z;

    float g = 2f;  //on some unknown eXoplanet, so who knows what g it has ? 
    float thrust = 2f;
    Vector3 gravity;

    Vector3 zero = new Vector3(0f, 0f, 0f);
    Vector3 origin = new Vector3(0f, 0f, 0f);

    Vector3 gradient, parametric, normal;

    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        x = 0f;
        z = 0f;
        y = terrain.SampleHeight(new Vector3(x, 0f, z));
        pos = new Vector3(x, y, z);
        transform.position = pos;

        vel = zero;
        acc = zero;
        gravity = new Vector3(0, -g, 0);
    }

    // Update is called once per frame
    void Update()
    {
        acc = zero;  //reset, to start a new update cycle from scratch
        acc = Vector3.Dot(transform.forward, gravity) * transform.forward;
        vel = vel + Time.deltaTime * acc;

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

        x = x + Time.deltaTime * vel.x;
        z = z + Time.deltaTime * vel.z;
        y = terrain.SampleHeight(new Vector3(x, 0f, z));

        transform.position = new Vector3(x, y, z);

        normal = terrain.GetComponent<TerrainCollider>().terrainData.GetInterpolatedNormal((x + 100f) / 200f, (z + 100f) / 200f).normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, normal).normalized, normal);

    }

}