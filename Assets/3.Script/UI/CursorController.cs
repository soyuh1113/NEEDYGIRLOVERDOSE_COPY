using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CursorType
{
    Horizontal_L,
    Horizontal_R,
    Vertical_U,
    Vertical_D,
    Diagonal_LU,
    Diagonal_LD,
    Diagonal_RU,
    Diagonal_RD
}

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{
    public CursorType cursorType;

    private WindowController windowController;

    [SerializeField] private Texture2D[] cursor_Img;
    public static bool resizing = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        resizing = true;

        switch (cursorType)
        {
           case CursorType.Horizontal_L:
                Cursor.SetCursor(cursor_Img[2], Vector2.zero, CursorMode.ForceSoftware);
               break;
            case CursorType.Horizontal_R:
                Cursor.SetCursor(cursor_Img[2], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Vertical_U:
                Cursor.SetCursor(cursor_Img[1], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Vertical_D:
                Cursor.SetCursor(cursor_Img[1], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal_LU:
                Cursor.SetCursor(cursor_Img[3], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal_LD:
                Cursor.SetCursor(cursor_Img[4], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal_RU:
                Cursor.SetCursor(cursor_Img[4], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.Diagonal_RD:
                Cursor.SetCursor(cursor_Img[3], Vector2.zero, CursorMode.ForceSoftware);
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
        windowController.cursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Confined;

        windowController.originPos = windowController.uiTarget.position;
        windowController.originMousePos = eventData.position;

        windowController.uiTarget.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        windowController = GetComponent<WindowController>();

        RectTransform uiRectTransform = windowController.uiTarget.GetComponent<RectTransform>();
        RectTransform parentRectTransform = windowController.uiTarget.parent.GetComponent<RectTransform>();

        Vector2 dragAmount = eventData.position - windowController.originMousePos;
        Vector2 newSize = uiRectTransform.sizeDelta;
        
        switch (cursorType)
        {
            case CursorType.Horizontal_L:
                newSize.x -= dragAmount.x;
                break;
            case CursorType.Horizontal_R:
                newSize.x += dragAmount.x;
                break;
            case CursorType.Vertical_U:
                newSize.y += dragAmount.y;
                break;
            case CursorType.Vertical_D:
                newSize.y -= dragAmount.y;
                break;
            case CursorType.Diagonal_LU:
                newSize.x += dragAmount.x;
                newSize.y -= dragAmount.y;
                break;
            case CursorType.Diagonal_LD:
                newSize.x -= dragAmount.x;
                newSize.y -= dragAmount.y;
                break;
            case CursorType.Diagonal_RU:
                newSize.x -= dragAmount.x;
                newSize.y += dragAmount.y;
                break;
            case CursorType.Diagonal_RD:
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
       
        windowController.originMousePos = eventData.position;
       
        ClampToParent(uiRectTransform, parentRectTransform);
    }

    private void ClampToParent(RectTransform uiRectTransform, RectTransform parentRectTransform)
    {
        Vector3[] parentCorners = new Vector3[4];
        parentRectTransform.GetWorldCorners(parentCorners);

        Vector3[] uiCorners = new Vector3[4];
        uiRectTransform.GetWorldCorners(uiCorners);

        Vector2 clampedPosition = uiRectTransform.anchoredPosition;

        float minX = parentCorners[0].x + (uiRectTransform.rect.width * uiRectTransform.lossyScale.x) / 2;
        float maxX = parentCorners[2].x - (uiRectTransform.rect.width * uiRectTransform.lossyScale.x) / 2;

        float minY = parentCorners[0].y + (uiRectTransform.rect.height * uiRectTransform.lossyScale.y) / 2;
        float maxY = parentCorners[2].y - (uiRectTransform.rect.height * uiRectTransform.lossyScale.y) / 2;

        clampedPosition.x = Mathf.Clamp(uiRectTransform.position.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(uiRectTransform.position.y, minY, maxY);

        uiRectTransform.position = clampedPosition;
    }
}
