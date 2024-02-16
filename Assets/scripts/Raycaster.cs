using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Raycaster : MonoBehaviour
{
    private Camera GetCamera;
    private IInputSystem _inputSystem;
    private InventoryController _inventoryController;
    [SerializeField] private LayerMask ItemLayer;
    [SerializeField] private Transform RaycastGuide;
    [Inject]
    private void Constructor(IInputSystem inputSystem, InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        _inputSystem = inputSystem;
    }
    private void Start()
    {
        GetCamera = Camera.main;
        print(ItemLayer.value);
        Cursor.lockState = CursorLockMode.Locked;
        InventoryUi.OnActivateObject += ActivateDropRaycast;
    }

    private void ActivateDropRaycast(ItemObject obj)
    {
        Ray ray = GetCamera.ScreenPointToRay(_inputSystem.MousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 7))
        {
            
            
                obj.gameObject.SetActive(true);
                obj.transform.position = hit.point;
                print("RAYCAST1331");
            
        }
        else
        {
            print("RAYCAST1221");
            obj.gameObject.SetActive(true);
            obj.transform.position = RaycastGuide.transform.position;
        }
    }
    private void Update()
    {
        if(_inputSystem.IsGrab)
        {
            Ray ray = GetCamera.ScreenPointToRay(_inputSystem.MousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 7, Color.red);
            if (Physics.Raycast(ray, out hit, 7, ItemLayer))
            {
                //print(hit.transform.name);
                hit.collider.gameObject.TryGetComponent<ItemObject>(out ItemObject itemObject);
                if (itemObject!= null)
                {
                    print("it exists 2");

                    _inventoryController.AddItem(itemObject);
                    
                }
                
            }
        }
    }
    
}
