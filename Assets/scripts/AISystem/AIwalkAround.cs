using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIwalkAround : AIbehaviour
{
    public override bool CheckBehaviour()
    {
        return true;
    }

    public override void UpdateBehaviour()
    {
        print("walking around");
    }
}
