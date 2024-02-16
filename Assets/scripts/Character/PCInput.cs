using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PCInput : IInputSystem
{
    public Vector2 Axis => GetMoveVector();
    public bool IsGrab => Input.GetKey(KeyCode.E);
    public Vector2 RotationVector => GetRotationVector();
    public Vector2 MousePosition => Input.mousePosition;
    public bool IsInvOpen => Input.GetKeyDown(KeyCode.Tab);
    private Vector2 GetMoveVector()
    {
        
        Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return moveVector;
    }
    private Vector2 GetRotationVector()
    {
        Vector2 RotVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        return RotVector;
    }
}
