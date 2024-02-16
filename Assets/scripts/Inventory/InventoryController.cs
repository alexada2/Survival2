using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Dictionary<ObjectTypes, ItemInfo> _items = new Dictionary<ObjectTypes, ItemInfo>();
    public List<ItemObject> itemObjects;
    [SerializeField] private int MaxAmount;
    InventoryUi InvetoryUI;
    [Inject]
    public void Constructor(InventoryUi _inventoryUi)
    {
        InvetoryUI = _inventoryUi;
    }
    private void Start()
    {
        int Attemp = 1;

        while (true)
        {
            var item = Resources.Load<ItemInfo>("ItemInformations/Item" + Attemp);
            Attemp += 1;
            if (item == null)
            {
                break;
            }
            ObjectTypes type = item.Type;

            print(item + ", " + type);
            _items.Add(type, item);
        }
        
        
    }
    public void AddItem(ItemObject Item)
    {
        ItemInfo CurrentItem =GetItemInfo(Item.type);

        //if (_items.TryGetValue(Item.Type, out ItemInfo CurrentItem))
        //{
        //    if (CurrentItem.ItemCount < MaxAmount)
        //    {
        //        CurrentItem.ItemCount += Item.ItemCount; return;
        //    }
        //}
        InvetoryUI.NewCell(CurrentItem, Item);
        
        itemObjects.Add(Item);
        Item.gameObject.SetActive(false);
        print(itemObjects[0]);
    }

    public void DropItem(ItemObject item)
    {
        itemObjects.Remove(item);
    }
    public ItemInfo GetItemInfo(ObjectTypes objectType)
    {
        _items.TryGetValue(objectType, out ItemInfo itemInfo);
       
        return itemInfo;
    }
    //public void UseItem(string ItemName)
    //{
    //    foreach (ItemEntity item in items)
    //    {
    //        if (item.name == ItemName)
    //        {
    //            item.ItemScript.SendMessage("Action");
    //            return;
    //        }
    //    }
    //}
}
