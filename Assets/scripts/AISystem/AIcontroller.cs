using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : MonoBehaviour
{
    public AIbehaviour[] aIbehaviours;
    private void Update()
    {
        foreach(AIbehaviour behaviour in aIbehaviours)
        {
            if (behaviour.CheckBehaviour())
            {
                behaviour.UpdateBehaviour();
                break;
            }
        }
    }
}
