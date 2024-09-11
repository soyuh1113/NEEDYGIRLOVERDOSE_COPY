using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Transform uiTarget;

    private Vector2 originPos;
    private Vector2 originMousePos;
    private Vector2 movePos;

    private Vector2 originSize;

    //[SerializeField] private Sprite

    //private bool isResizedToParent = false;

    private CursorLockMode cursorLockMode;

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //private void ClampToParent(RectTransform )
}
