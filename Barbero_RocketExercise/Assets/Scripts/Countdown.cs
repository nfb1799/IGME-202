using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    float tT;
    bool begin = false;

    void Start()
    {
        tT = 0f;
        OnGUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            begin = true;
        if(begin)
        {
            tT += Time.deltaTime;
            OnGUI();
        }
            
    }

    void OnGUI()
    {
        if(tT == 0f)
        {
            GUI.skin.box.wordWrap = true;
            GUI.skin.box.fontSize = 22;
            GUI.Box(new Rect(10, 10, 120, 100), "Press '0' to begin the countdown.");
        }

        if (tT > 0f)
        {
            
            GUI.skin.box.fontSize = 44;
            if (tT < 1f)
                GUI.Box(new Rect(10, 10, 120, 100), "3");
            else if (1f < tT && tT < 2f)
                GUI.Box(new Rect(10, 10, 120, 100), "2");
            else if (2f < tT && tT < 3f)
                GUI.Box(new Rect(10, 10, 120, 100), "1");
            else if (tT > 3f)
                GUI.Box(new Rect(10, 10, 120, 100), "LAUNCH");
        }
    }
}
