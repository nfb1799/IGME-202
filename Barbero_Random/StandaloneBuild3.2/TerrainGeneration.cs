using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainGeneration : MonoBehaviour
{

    private TerrainData myTerrainData;
    public Vector3 worldSize;
    public int resolution = 129;
    float[,] heightArray;


    void Start()
    {
        myTerrainData = gameObject.GetComponent<TerrainCollider>().terrainData;
        worldSize = new Vector3(200, 50, 200);
        myTerrainData.size = worldSize;
        myTerrainData.heightmapResolution = resolution;
        heightArray = new float[resolution, resolution];

        //Flat(1.0f);
        //Ramp();
        Perlin();

        myTerrainData.SetHeights(0, 0, heightArray);
    }


    void Update()
    {

    }


    void Flat(float value)
    {
        // Fill heightArray with 1's
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                heightArray[i, j] = value;
            }
        }
    }


    
    void Ramp()
    {
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                heightArray[i, j] = (i/resolution);
            }
        }
    }

    /// <summary>
    /// Perlin()
    /// Assigns heightsArray values using Perlin noise
    /// </summary>
    void Perlin()
    {
        // Perlin noise value - this is the starting "index" where the PerlinNoise function

        float originate = Random.Range(0.0f, 100.0f);

        float xIndex = originate;
        float yIndex = originate;

        // Fill heightArray with Perlin generated values

        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {

                yIndex += 0.020f;
                heightArray[i, j] = Mathf.PerlinNoise(xIndex, yIndex);
            }


            yIndex = originate;

            xIndex += .020f;
        }

    }
    // Fill heightArray with Perlin-based values
}
