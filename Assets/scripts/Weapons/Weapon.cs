using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Vector3 rTargetPosition;
    [SerializeField] private Vector3 rHintPosition;
    [SerializeField] private Vector3 rTargetRotation;
    [SerializeField] private Vector3 lTargetPosition;
    [SerializeField] private Vector3 lHintPosition;
    [SerializeField] private Vector3 lTargetRotation;
    public void Pose(Transform rTarget, Transform rHint)
    {
        rTarget.localPosition = rTargetPosition;
        rHint.localPosition = rHintPosition;
        rTarget.localRotation = Quaternion.Euler(rTargetRotation);
    }
}
