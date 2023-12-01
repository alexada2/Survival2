using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Test : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private int a = 6;
    private int b = 2;
    private bool f = false;
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
    }
  
    void Start()
    {
        bool c = a / b == 3 ? f = true : f = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}