using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public bool walking;
    // Start is called before the first frame update
    void Start()
    {
        walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") && Input.GetKey("d"))
            transform.Translate(1, 0, 1);
        else if (Input.GetKey("a") && Input.GetKey("w"))
            transform.Translate(-1, 0, 1);
        else if (Input.GetKey("a") && Input.GetKey("s"))
            transform.Translate(-1, 0, -1);
        else if (Input.GetKey("d") && Input.GetKey("s"))
            transform.Translate(1, 0, -1);
        else if (Input.GetKey("a"))
            transform.Translate(-1, 0, 0);
        else if (Input.GetKey("d"))
            transform.Translate(1, 0, 0);
        else if (Input.GetKey("w"))
            transform.Translate(0, 0, 1);
        else if (Input.GetKey("s"))
            transform.Translate(0, 0, -1);

        if (Input.GetKeyDown("m"))
            walking = !walking;

        if (walking)
            transform.Translate(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));


    }
}
