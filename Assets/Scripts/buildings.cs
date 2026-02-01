using System.Diagnostics.Tracing;
using UnityEngine;

public class buildings : MonoBehaviour
{
    public Vector3 start_position = new Vector3(10, -12, 60);
    public Vector3 end_position = new Vector3(10, 0, -10);
    Vector3 direction;
    [SerializeField] private Animator driverAnimator;


    public float speed;

    void Start()
    {
        transform.position = start_position;
        direction = end_position - start_position;

    }

    void Update()
    {
        if (driverAnimator.GetBool("GameStart"))
        {
            transform.position += direction * speed;
            if (transform.position.z <= end_position.z)
            {
                transform.position = start_position;
            }
        }

    }
}
