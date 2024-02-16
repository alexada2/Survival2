using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public TextMeshProUGUI Amount;
    public Image Image;
    public ObjectTypes Type;
    public TextMeshProUGUI NameText;
    private LayoutElement layoutElement;
    private Vector2 offset;
    private RectTransform rectTransform;
    public Transform PoolTransform;
    private Transform DefaultParent;
    public ItemObject GetItemObject;
    public static event Action<InventoryCell> OnDrop;

    private void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        layoutElement = gameObject.AddComponent<LayoutElement>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(PoolTransform);
        layoutElement.ignoreLayout = true;
        
        offset = rectTransform.position - Input.mousePosition;
    }
    public void Start()
    {
        DefaultParent = transform.parent;
    }
    public void OnDrag(PointerEventData eventData)
    {
        
         rectTransform.position = new Vector2(Input.mousePosition.x + offset.x, Input.mousePosition.y + offset.y);
        

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        OnDrop?.Invoke(this);
        transform.SetParent(DefaultParent);
       layoutElement.ignoreLayout = false;
        offset = Vector2.zero;
    }

    

   
}
