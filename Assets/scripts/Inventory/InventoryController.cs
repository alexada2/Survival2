using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private ItemEntity[] items;
    [SerializeField] private Dictionary<string, ItemEntity> _items;

    public void AddItem(ItemEntity Item)
    {
        items.SetValue(Item, items.Length);
    }

    public void DropItem(int ItemIndex)
    {
        items.SetValue(null, ItemIndex);
    }

    public void UseItem(string ItemName)
    {
        foreach (ItemEntity item in items)
        {
            if (item.name == ItemName)
            {
                item.ItemScript.SendMessage("Action");
                return;
            }
        }
    }
}
