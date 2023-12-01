using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackComponent
{
    [Range(0,360)] public float Angle;
    public float Radius;
    public LayerMask Player;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
        Quaternion leftAngleRot = Quaternion.AngleAxis(Angle / 2, transform.up);
        Quaternion rightAngleRot = Quaternion.AngleAxis(-Angle / 2 , transform.up);
        Vector3 leftAngleDir = leftAngleRot * transform.forward;
        Vector3 rightAngleDir = rightAngleRot * transform.forward;
        Gizmos.DrawRay(transform.position, leftAngleDir * Radius);
        Gizmos.DrawRay(transform.position, rightAngleDir * Radius);
    }
    public override void OnAttack() {
        Collider[] colliders;
        colliders = Physics.OverlapSphere(transform.position, Radius, Player);
        foreach (Collider col in colliders)
        {
            Vector3 dir = col.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, dir);
            if (angle <= Angle)
            { 
                Destroy(col.gameObject);
            }
        }
    }
}
