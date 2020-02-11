using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
    public bool walking;
    public GameObject walker;
    // Start is called before the first frame update
    void Start()
    {
        walking = false;
        Instantiate(walker, new Vector3(0, 0.5f, 0), Quaternion.identity);
        OnGUI();
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

        if (transform.position.x > 50 || transform.position.x < -50 || transform.position.z > 50 || transform.position.z < -50)
            Reset();
    }

    void Reset()
    {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    void OnGUI()
    {
        GUI.skin.box.wordWrap = true;
        GUI.Box(new Rect(10, 10, 200, 55), "Press the 'm' key to start and stop the walker. Or use WASD to control the walker.");
    }
}
