using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public Joystick Joystick;
    public Joystick JoystickRotation;
    public Factory GetFactory;
    public override void InstallBindings()
    {
        BindData();
        RegisterInputSystem();
        RegisterFactory();
    }

    private void BindData() =>
    Container.Bind<PlayerData>().FromNew().AsSingle();

    private void RegisterInputSystem()
    {
        IInputSystem inputSystem = Application.isMobilePlatform
       ? new MobileInputSystem(Joystick, JoystickRotation)
       : new PCInput();
         Container.Bind<IInputSystem>().FromInstance(inputSystem).AsSingle();
    }
    private void RegisterFactory()
    {
        Container.InstantiatePrefab(GetFactory);
    }
}

