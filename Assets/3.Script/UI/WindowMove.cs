using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowMove : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Transform uiTarget;

    public Vector2 originPos;
    public Vector2 originMousePos;
    public Vector2 movePos;

    [SerializeField] private Sprite active_Img;
    [SerializeField] private Sprite inactive_Img;

    public CursorLockMode cursorLockMode;

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
