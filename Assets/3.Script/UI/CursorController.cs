using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D Change_Cursor1;

    public bool Change_Cursor = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Change_Cursor = true;
        Cursor.SetCursor(Change_Cursor1, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Change_Cursor = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
