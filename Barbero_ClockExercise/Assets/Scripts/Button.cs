using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject clockHand;
    

    // Start is called before the first frame update
    void Start()
    {
        clockHand = GameObject.Find("ClockHand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {

        var script = clockHand.GetComponent<RotateHand>();
        script.enabled = !script.enabled;
        Debug.Log("click");
    }
}
