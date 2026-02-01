using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class start_Game : MonoBehaviour
{
    [SerializeField] private CinemachineCamera mainCamera;
    [SerializeField] private GameObject princessCharacter;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Animator driverAnimator;
    [SerializeField] private Button startButton;
    [SerializeField] private Image logoImage;

    private void Start()
    {
     //   driverAnimator = GetComponent<Animator>();
    }

    public void OnButtonClick()
    {
        // StartCoroutine(MovePrincess());
        mainCamera.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        logoImage.gameObject.SetActive(false);
        driverAnimator.SetBool("GameStart", true);

        Invoke("ArmAppears", 2);
        Invoke("TurnOnScreen", 2);
    }

    void TurnOnScreen()
    {
        if (!driverAnimator.GetBool("Phone"))
        {
            driverAnimator.SetBool("Phone", true);
        }
        Invoke("TurnOnScreen", 2);
    }

    private void ArmAppears()
    {
        princessCharacter.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private IEnumerator MovePrincess()
    {
        while (Vector3.Distance(princessCharacter.transform.position, targetPosition) > 0.1f)
        {
            princessCharacter.transform.position =
                Vector3.MoveTowards(
                    princessCharacter.transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime
                );

            yield return null; // MUST be inside the loop
        }
    }
}
