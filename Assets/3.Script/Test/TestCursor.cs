using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum NCursorType
{
    None,
    Horizontal1,
    Horizontal2,
    Vertical1,
    Vertical2,
    Diagonal1,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
    Diagonal2,
    Diagonal3,
    Diagonal4,
}

public class TestCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{
    public NCursorType cursorType = NCursorType.None;

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
            case NCursorType.Horizontal1:
                Cursor.SetCursor(cursor_Img[1], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Horizontal2:
                Cursor.SetCursor(cursor_Img[1], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Vertical1:
                Cursor.SetCursor(cursor_Img[2], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Vertical2:
                Cursor.SetCursor(cursor_Img[2], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Diagonal1:
                Cursor.SetCursor(cursor_Img[3], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Diagonal2:
                Cursor.SetCursor(cursor_Img[4], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Diagonal3:
                Cursor.SetCursor(cursor_Img[3], Vector2.zero, CursorMode.ForceSoftware);
                break;
            case NCursorType.Diagonal4:
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
            case NCursorType.Horizontal1:
                newSize.x -= dragAmount.x;
                break;
            case NCursorType.Horizontal2:
                newSize.x += dragAmount.x;
                break;
            case NCursorType.Vertical1:
                newSize.y += dragAmount.y;
                break;
            case NCursorType.Vertical2:
                newSize.y -= dragAmount.y;
                break;
            case NCursorType.Diagonal1:
                newSize.x += dragAmount.x;
                newSize.y -= dragAmount.y;
                break;
            case NCursorType.Diagonal2:
                newSize.x -= dragAmount.x;
                newSize.y -= dragAmount.y;
                break;
            case NCursorType.Diagonal3:
                newSize.x -= dragAmount.x;
                newSize.y += dragAmount.y;
                break;
            case NCursorType.Diagonal4:
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

