using UnityEditor.UI;
using UnityEngine;

public class hand_movement : MonoBehaviour
{
    Rigidbody handRb;
    public float speed;

    float mouse_x;
    float mouse_y;
    float scroll;

    void Start()
    {
        handRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mouse_x = Input.GetAxisRaw("Mouse X");
        mouse_y = Input.GetAxisRaw("Mouse Y");
        scroll = Input.mouseScrollDelta.y;
    }

    void FixedUpdate()
    {
        Move(handRb, new Vector3(mouse_x, scroll, mouse_y), speed);
    }

    public static void Move(Rigidbody rigidbody, Vector3 direction, float speed)
    {
        Vector3 targetVelocity = direction.normalized * speed;
        // targetVelocity.y = rigidbody.linearVelocity.y;
        rigidbody.linearVelocity = targetVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("head"))
        {
            Debug.Log("head hit");
        }
    }
}
