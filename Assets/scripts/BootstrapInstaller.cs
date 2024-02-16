
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public Joystick Joystick;
    public Joystick JoystickRotation;
    public InventoryUi InventoryUi;
    public InventoryController inventoryController;
    public Factory GetFactory;
    public Canvas GetCanvas;
    public override void InstallBindings()
    {
        BindData();
        RegisterInputSystem();
        RegisterInventory();
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
    private void RegisterInventory()
    {
        InventoryUi InvUI = Container.InstantiatePrefab(InventoryUi, GetCanvas.transform).GetComponent<InventoryUi>();
        Container.Bind<InventoryUi>().FromInstance(InvUI).AsSingle();
        InventoryController InvContrl = Container.InstantiatePrefab(inventoryController).GetComponent<InventoryController>();
        Container.Bind<InventoryController>().FromInstance(InvContrl).AsSingle();
    }
}

