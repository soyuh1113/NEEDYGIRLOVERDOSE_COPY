using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D Change_Cursor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(Change_Cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
