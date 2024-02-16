using UnityEngine;

public class MobileInputSystem : IInputSystem
{
    private Joystick _joystick;
    private Joystick _joystickRotate; 
    public MobileInputSystem(Joystick joystick, Joystick joystickRotate)
    {
        _joystick = joystick;
        _joystickRotate = joystickRotate;
    }

    public Vector2 Axis => _joystick.Direction;
    public bool IsGrab => false;  //заменить
    public Vector2 RotationVector => _joystickRotate.Direction;
    public Vector2 MousePosition => Input.mousePosition;
    public bool IsInvOpen => Input.GetKey(KeyCode.Tab);

}
