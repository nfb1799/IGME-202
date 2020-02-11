using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                SceneManager.LoadScene(1);
            if (SceneManager.GetActiveScene().buildIndex == 1)
                SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        GUI.skin.box.wordWrap = true;
        GUI.Box(new Rect(220, 10, 100, 55), "Press the 'c' key to change scenes.");
    }
}
