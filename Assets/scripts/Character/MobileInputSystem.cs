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

    public Vector2 MousePosition => _joystickRotate.Direction;
}
