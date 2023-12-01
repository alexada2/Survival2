using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IInputSystem 
{
    //[SerializeField] private float Speed;
    //[SerializeField] private float CameraSpeed;
    //[SerializeField] private Camera GetCamera;
    //[SerializeField] private PlayerMovement GetCharacterController;
    //private PlayerData data;
    //public float health;
    public Vector2 Axis { get; }
    public Vector2 MousePosition { get; }
    //[Inject]
    //public void Construct(PlayerData playerData)
    //{
    //    data = playerData;
    //    Speed = data.Speed;
    //}
    //void Update()
    //{
    //    float mousex = Input.GetAxis("Mouse X");
    //    float mousey = Input.GetAxis("Mouse Y");
    //    float movex = Input.GetAxis("Horizontal");
    //    float movez = Input.GetAxis("Vertical");
    //    Vector3 move = new Vector3(movex, 0, movez);
    //    //GetCharacterController.RotateTo(mousey, mousex, GetCamera, CameraSpeed);
    //    //GetCharacterController.Move(move, Speed);
    //}
}
