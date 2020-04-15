using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainGeneration : MonoBehaviour 
{

	private TerrainData myTerrainData;
	public Vector3 worldSize;
	public int resolution = 129;			// number of vertices along X and Z axes
	float[,] heightArray;
    public Vector3 originate; 

    void Start () 
	{
        myTerrainData = gameObject.GetComponent<TerrainCollider> ().terrainData;
		worldSize = new Vector3 (200, 100, 200); 
		myTerrainData.size = worldSize;
		myTerrainData.heightmapResolution = resolution;
		heightArray = new float[resolution, resolution];

        //originate = new Vector3(65.78028f, 0, 28.30647f);  //two values that just do happen to produce continuously looping paths for Cyli and Caps
        originate = new Vector3(Random.Range(0.0f, 100.0f), 0, Random.Range(0.0f, 100.0f)) ; // start sampling from random locations in PerlinNoiseLand

        Perlin(originate, resolution);

        myTerrainData.SetHeights(0, 0, heightArray);
        gameObject.transform.Translate(-100f, 0f, -100f); //so that it is centered around the origin
	}
   
    void Perlin(Vector3 originate, int resolution)
	{
    
       float xIndex = originate.x;
       float zIndex = originate.z;
       float range = 1.28f; //how far to go in the space we'll call "PerlinNoiseLand" to collect samples
       float stepSize = range / (resolution-1); //separation between sample spots

            // Fill heightArray with Perlin generated values

            for (int k = 0; k < resolution; k++)
            {
                for (int i = 0; i < resolution; i++)
                {

                    xIndex += stepSize;
                    heightArray[k, i] = Mathf.PerlinNoise(xIndex, zIndex);
                }
     
                xIndex = originate.x;  //reset to sweep out along the beginning of the next row

                zIndex += stepSize;  //step forward to the next row
            }
   
    }

}
