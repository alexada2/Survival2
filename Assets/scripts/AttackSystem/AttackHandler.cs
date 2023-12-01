using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public AttackComponent[] attacks;
    [ContextMenu("TryAttack")]
    public void TryAttack()
    {
        foreach (AttackComponent attack in attacks)
        {
            attack.OnAttack();
        }
    }
}
