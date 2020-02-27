using UnityEngine;

public class RockMover : MonoBehaviour
{
	public float speed = -2f;
    Vector3 pos;


    void Update()
    {
        pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.y <= -8)
            Destroy(gameObject);
    }
}
