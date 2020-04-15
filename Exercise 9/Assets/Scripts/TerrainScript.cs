using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    private TerrainData myTerrainData;
    public Vector3 worldSize;
    public int resolution;
    float[,] heightArray;
    float theta;

    // Start is called before the first frame update
    void Start()
    {
        myTerrainData = gameObject.GetComponent<TerrainCollider>().terrainData;
        worldSize = new Vector3(200, 200, 200);
        myTerrainData.size = worldSize;
        resolution = 129;
        myTerrainData.heightmapResolution = resolution;
        heightArray = new float[resolution, resolution];
        theta = 15.0f;
        Slope(theta);
        myTerrainData.SetHeights(0, 0, heightArray);
        transform.position = new Vector3(-100, -100 * Mathf.Tan(Mathf.Deg2Rad * theta), -100);
    }

    void Slope(float theta)
    {
        for (int k = 0; k < resolution; k++)
            for (int i = 0; i < resolution; i++)
                heightArray[k, i] = Mathf.Tan(Mathf.Deg2Rad * theta) * (float)k / (resolution - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
