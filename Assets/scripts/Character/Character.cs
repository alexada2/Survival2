using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;

    public void Move(Vector3 Direction, float sps)
    {
        Direction.Normalize();
        Vector3 movement = Direction.x * transform.right + Direction.z * transform.forward;
        Rigidbody.MovePosition(transform.position + movement * sps * Time.deltaTime);
    }
}
