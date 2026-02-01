using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAnimationConfigJoint : MonoBehaviour
{
    public GameObject animatedGameObjectReference;
    ConfigurableJoint ragdollCj;
    Quaternion initialRotation;
    public bool isTrackingReference = true;

    void Start()
    {
        ragdollCj = GetComponent<ConfigurableJoint>();
        initialRotation = transform.localRotation;
    }

    void Update()
    {
            ragdollCj.targetRotation = Quaternion.Inverse(animatedGameObjectReference.transform.localRotation) * initialRotation;
    }
}
