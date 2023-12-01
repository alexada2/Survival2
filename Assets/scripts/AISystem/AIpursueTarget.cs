using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpursueTarget : AIbehaviour
{
    public float Radius;
    public LayerMask TargetLayer;
    public GameObject Target;

    
    public override bool CheckBehaviour()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius, TargetLayer);
        if  (colliders.Length > 0)
        {
            Target = colliders[0].gameObject;
            
            
            return true;
        }
        Target = null;
        return false;
    }

    public override void UpdateBehaviour()
    {
        Character.CalculatePath(Target.transform.position);
        Character.MoveByPath();
    }
}
