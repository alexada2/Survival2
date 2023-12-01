using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemEntity : MonoBehaviour
{
    public string ItemName { get { return itemName; } }
    [SerializeField] private string itemName;
     public GameObject ItemPrefab { get { return itemPrefab; } }
    [SerializeField] private GameObject itemPrefab;
     public MonoBehaviour ItemScript { get { return itemScript; } }
    [SerializeField] private MonoBehaviour itemScript;
    public int ItemCount;     
}
