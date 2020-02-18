using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    public GameObject prefab;
    private const float radius = 2.0F;
    private float deg;
    private float rad;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        deg = 0.0F;
  
        for (int i = 1; i <= 12; i++)
        {
            prefab.GetComponentInChildren<TextMesh>().text = i.ToString();
            rad = Mathf.Deg2Rad * deg;
            x = radius * Mathf.Acos(rad);
            y = radius * Mathf.Asin(rad);
            Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
            deg += 30.0F;
        }
        /*for (int i = 1; i <= 12; i++)
        {
            prefab.GetComponentInChildren<TextMesh>().text = i.ToString();
            x = radius * Mathf.Acos(Mathf.Deg2Rad * (30.0F * i));
            y = radius * Mathf.Asin(Mathf.Deg2Rad * (30.0F * i));
            Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        }
        /*prefab.GetComponentInChildren<TextMesh>().text = "12";
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
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
