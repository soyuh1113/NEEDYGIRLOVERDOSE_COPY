using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D[] cursor_Img;
    public bool resizing = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        resizing = true;
        Cursor.SetCursor(cursor_Img[2], Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        resizing = false;
        Cursor.SetCursor(cursor_Img[0], Vector2.zero, CursorMode.ForceSoftware);
    }
}
