using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PCInput : IInputSystem
{
    public Vector2 Axis => GetMoveVector();

    public Vector2 MousePosition => GetRotationVector();

    //    float mousex = Input.GetAxis("Mouse X");
    //    float mousey = Input.GetAxis("Mouse Y");
    
    private Vector2 GetMoveVector()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return moveVector;
    }
    private Vector2 GetRotationVector()
    {
        Vector2 RotVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        return RotVector;
    }
}
