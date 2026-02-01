using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class start_Game : MonoBehaviour
{
    [SerializeField] private CinemachineCamera mainCamera;
    [SerializeField] private GameObject princessCharacter;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveSpeed = 1f;

    public void OnButtonClick()
    {
        
        StartCoroutine(MovePrincess());
        gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
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
