using UnityEngine;

public class hand_control : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " clicked");
    }

    void OnMouseEnter()
    {
        Debug.Log(gameObject.name + " under mouse");
    }
}
