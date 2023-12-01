using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIbehaviour : MonoBehaviour
{
    public BotMove Character;
    public abstract bool CheckBehaviour();
    public abstract void UpdateBehaviour();
}
