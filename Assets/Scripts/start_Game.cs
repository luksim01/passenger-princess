using Unity.Cinemachine;
using UnityEngine;


// When button is clicked, onClick event

// The Main_CinemachineCamera that is currently disabled will be enabled
public class start_Game : MonoBehaviour
{
    [SerializeField] private CinemachineCamera mainCamera;



  // called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnButtonClick()
    {
        mainCamera.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        
    }

    // Start is 

    // Update is called once per frame
    void Update()
    {
        
    }
}
