using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollLevel : MonoBehaviour
{
    Vector3 pos;
    Vector3 vel;

    float speed;
    float x, y, z;
 
    Vector3 zero = new Vector3(0f, 0f, 0f);
    Vector3 origin = new Vector3(0f, 0f, 0f);

    Vector3 grad, normal;


    // Start is called before the first frame update
    void Start()
    {
        x = 0f;
        z = 0f;
        y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0f, z));// - 25f; //Note that -25f is necessary to adjust for the translation of the Terrain
        pos = new Vector3(x, y, z);
        transform.position = pos;

        vel = zero;
        speed = 32f;
      
    }

    // Update is called once per frame
    void Update()
    {

        if (-100f < x && x < 100f && -100f < z && z < 100f) //there is no else, so the motion should just stop at the terrain's edge
        {
            normal = Terrain.activeTerrain.GetComponent<TerrainCollider>().terrainData.GetInterpolatedNormal((x + 100f) / 200f, (z + 100f) / 200f);

            //grad = Vector3.ProjectOnPlane(normal, new Vector3(0f,1f,0f); //projection of the normal vector onto the x-z plane
            grad = new Vector3(normal.x, 0f, normal.z); //equivalent to the above, more efficient and precise

            //only one of the following four should be uncommented, based on the desired behavior (e.g. go higher, go lower, stay level to , go right & stay left)  

            //vel = speed * grad; //direction of steepest descent 
            //vel = speed * (new Vector3(-grad.x, 0f, -grad.z));  //opposite to the vel in previous statement                                                                     
            //vel = speed * (new Vector3(-grad.z, 0f, grad.x));  //perpendicular to both of the above
            vel = speed * (new Vector3(grad.z, 0f, -grad.x));  //opposite to the vel in previous statement

            x = x + Time.deltaTime * vel.x;
            z = z + Time.deltaTime * vel.z;

            y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0f, z));

            transform.position = new Vector3(x, y, z);

            normal = Terrain.activeTerrain.GetComponent<TerrainCollider>().terrainData.GetInterpolatedNormal((x + 100f) / 200f, (z + 100f) / 200f).normalized;

            transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, normal).normalized, normal);
        }
    }
}