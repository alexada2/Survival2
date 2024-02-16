using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemInfo : ScriptableObject
{
    public string ItemDescription; //{ get { return itemDescription; } }
    public ObjectTypes Type; //{ get { return type; } }
    public Sprite ItemSprite; //{ get { return itemSprite; } }
    public GameObject ItemPrefab;//{ get { return itemPrefab; } }

    //[SerializeField] private string itemDescription;
    //[SerializeField] private GameObject itemPrefab;
    //[SerializeField] private ObjectTypes type;
    //[SerializeField] private Sprite itemSprite;
}