using System.Diagnostics.Tracing;
using UnityEngine;

public class buildings : MonoBehaviour
{
    Vector3 start_position = new Vector3(10, -1, 60);
    Vector3 end_position = new Vector3(10, 4, -5);
    Vector3 direction;

    public float speed;

    void Start()
    {
        transform.position = start_position;
        direction = end_position - start_position;

    }

    void Update()
    {
        transform.position += direction * speed;
        if (transform.position.z <= end_position.z)
        {
            transform.position = start_position;
        }
    }
}
