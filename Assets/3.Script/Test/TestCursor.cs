using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CursorType
{
    None,
    Horizontal,
    Vertical,
    Diagonal1,
    Diagonal2,
    Diagonal3,
    Diagonal4,
}

public class TestCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{
    public CursorType cursorType = CursorType.None;

    [SerializeField] private Texture2D[] cursor_Img;
    public static bool resizing = false;

    [SerializeField] private Transform moveUITarget;
    private CursorLockMode cursorLockMode;
    private Vector2 originPos;
    private Vector2 originMousePos;

    public void OnPointerEnter(PointerEventData eventData)
    {
        resizing = true;

        switch (cursorType)
        {
            case CursorType.Horizontal:
                Cursor.SetCursor(cursor_Img[1], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Vertical:
                Cursor.SetCursor(cursor_Img[2], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal1:
                Cursor.SetCursor(cursor_Img[3], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal2:
                Cursor.SetCursor(cursor_Img[4], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal3:
                Cursor.SetCursor(cursor_Img[3], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal4:
                Cursor.SetCursor(cursor_Img[4], Vector2.zero, CursorMode.ForceSoftware);
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        resizing = false;
        Cursor.SetCursor(cursor_Img[0], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        cursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Confined;

        originPos = moveUITarget.position;
        originMousePos = eventData.position;

        moveUITarget.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform parentRectTransform = moveUITarget.parent.GetComponent<RectTransform>();
        RectTransform uiRectTransform = moveUITarget.GetComponent<RectTransform>();

        Vector2 dragAmount = eventData.position - originMousePos;

        Vector2 newSize = uiRectTransform.sizeDelta;

        //¼¼ºÐÈ­

        switch (cursorType)
        {
            case CursorType.Horizontal:
                newSize.x += dragAmount.x;
                break;
            case CursorType.Vertical:
                newSize.y -= dragAmount.y;
                break;
            case CursorType.Diagonal1:
                newSize.x -= dragAmount.x;
                newSize.y += dragAmount.y;
                break;
            case CursorType.Diagonal2:
                newSize.x -= dragAmount.x;
                newSize.y -= dragAmount.y;
                break;
            case CursorType.Diagonal3:
                newSize.x += dragAmount.x;
                newSize.y -= dragAmount.y;
                break;
            case CursorType.Diagonal4:
                newSize.x += dragAmount.x;
                newSize.y += dragAmount.y;
                break;
        }
        
        newSize.x = Mathf.Max(newSize.x, 135);
        newSize.y = Mathf.Max(newSize.y, 60);

        Vector2 parentSize = parentRectTransform.rect.size;
        newSize.x = Mathf.Min(newSize.x, parentSize.x);
        newSize.y = Mathf.Min(newSize.y, parentSize.y);

        uiRectTransform.sizeDelta = newSize;

        originMousePos = eventData.position;
    }
}

