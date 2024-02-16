using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IInputSystem 
{
    public bool IsGrab { get;  }
    public Vector2 Axis { get; }
    public Vector2 RotationVector { get; }
    public Vector2 MousePosition { get; }
    public bool IsInvOpen { get; }
}
