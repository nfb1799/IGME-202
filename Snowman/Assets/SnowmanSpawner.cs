using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanSpawner : MonoBehaviour
{
    public int i = 1;

    public GameObject snowman1;
    public GameObject cabin1;
    public GameObject cabin2;
    public Quaternion myRotation;
    // Start is called before the first frame update
    void Start()
    {
        myRotation = Quaternion.identity;
        myRotation.eulerAngles = new Vector3(0, -131.915F, 0);
        Instantiate(snowman1, new Vector3(13.5F, 0.5F, 22.0F), Quaternion.identity);
        Instantiate(cabin1, new Vector3(72.35F, 11.39F, 34.05F), Quaternion.identity);
        Instantiate(cabin2, new Vector3(73.03F, 11.39F, 51.79F), myRotation);
        Debug.Log(" i equals " + i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
