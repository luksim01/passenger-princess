using System.Collections;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody rb;
    public float force;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("Jump", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(ApplyForce());
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        Invoke("Jump", 2);
    }

    private IEnumerator ApplyForce()
    {
        while (true)
        {
            rb.AddForce(Vector3.up * 0.05f, ForceMode.Impulse);
            yield return new WaitForSeconds(5f);
        }
    }
}
