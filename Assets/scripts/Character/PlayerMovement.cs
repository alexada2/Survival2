using UnityEngine;
using UnityEngine.Windows;
using Zenject;

public class PlayerMovement : Character
{
    IInputSystem _inputSystem;
     private float OldMagntude;
    [Inject]
    private void Constructor(IInputSystem inputSystem)
    {

        _inputSystem = inputSystem;
    }
    private float xRot;
    private void Update()
    {
       if (_inputSystem == null) return;
        Move(new Vector3(_inputSystem.Axis.x*2, 0, _inputSystem.Axis.y*2), 3);
        Invoke("OldMagnitudeSet", Time.deltaTime * 2);
        if (_inputSystem.RotationVector.magnitude == OldMagntude) return;
        RotateTo(_inputSystem.RotationVector.y, _inputSystem.RotationVector.x, Camera.main, 7);
       
    }
    public void RotateTo(float mousey, float mousex, Camera GetCamera, float CameraSps)
    {
        xRot -= mousey;
        xRot = Mathf.Clamp(xRot, -35, 30);
        GetCamera.transform.localRotation = Quaternion.Euler(xRot * CameraSps, 0, 0);
        //GetCamera.transform.localRotation = Quaternion.Lerp(GetCamera.transform.rotation, GetCamera.transform.rotation*Quaternion.Euler(xRot, 0, 0), CameraSps*Time.deltaTime);
        transform.Rotate(0, mousex * CameraSps, 0);

    }
    private void OldMagnitudeSet()
    {
        OldMagntude = _inputSystem.RotationVector.magnitude;
    }
}
