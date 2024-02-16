using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
public class InventoryUi : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public List<InventoryCell> inventoryCells;
    public InventoryCell ItemCellPrefab;
    public Transform Parent;
    public IInputSystem InputSystem;
    private bool onui;
    private Transform pool;
    private InventoryController InventoryController;
    private DiContainer Container;
    public static event Action<ItemObject> OnActivateObject;
    [Inject]
    public void constructor(IInputSystem input, DiContainer container) //InventoryController controller)
    {
        InputSystem = input;
        // InventoryController = controller;
        Container = container;
    }
    public void Start()
    {
        InventoryCell.OnDrop += DropHandler;
        pool = gameObject.transform.parent.Find("MovingCell");
        
    }
    public void Update()
    {
       
        if (InputSystem.IsInvOpen)
        {
            if (!Parent.gameObject.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            Parent.gameObject.SetActive(!Parent.gameObject.activeSelf);
        }
        
    }
    public void NewCell(ItemInfo item, ItemObject item2)
    {
        var NewItemCell = Instantiate(ItemCellPrefab, Parent);
        //        NewItemCell.Image.sprite = item.ItemSprite;
        //NewItemCell.Amount.text = item.ItemCount.ToString();
        NewItemCell.NameText.text = item.Type.ToString();
        NewItemCell.PoolTransform = pool;
        NewItemCell.GetItemObject = item2;
    }
    public void RemoveCell(ItemInfo cell)
    {

        //Destroy(cell.gameObject);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        onui = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        onui = false;
    }
    private void DropHandler(InventoryCell cell)
    {
        if (InventoryController==null)
        {
            InventoryController = Container.Resolve<InventoryController>();

        }
       
        if (!onui)
        {
            OnActivateObject.Invoke(cell.GetItemObject);
            InventoryController.DropItem(cell.GetItemObject);
            Destroy(cell.gameObject);
        }
    }
}
