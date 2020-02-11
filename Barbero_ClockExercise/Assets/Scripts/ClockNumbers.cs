using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab.GetComponentInChildren<TextMesh>().text = "12";
        Instantiate(prefab, new Vector3(0, 2.3F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "1";
        Instantiate(prefab, new Vector3(1.25F, 2.0F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "2";
        Instantiate(prefab, new Vector3(2.0F, 1.0F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "3";
        Instantiate(prefab, new Vector3(2.3F, 0, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "4";
        Instantiate(prefab, new Vector3(2.0F, -1.2F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "5";
        Instantiate(prefab, new Vector3(1.25F, -2.0F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "6";
        Instantiate(prefab, new Vector3(0, -2.3F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "7";
        Instantiate(prefab, new Vector3(-1.25F, -2.0F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "8";
        Instantiate(prefab, new Vector3(-2.0F, -1.0F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "9";
        Instantiate(prefab, new Vector3(-2.3F, 0, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "10";
        Instantiate(prefab, new Vector3(-2.0F, 1.2F, 0), Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = "11";
        Instantiate(prefab, new Vector3(-1.25F, 2.0F, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
