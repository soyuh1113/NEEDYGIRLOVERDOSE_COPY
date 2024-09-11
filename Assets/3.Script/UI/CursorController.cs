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

public class CursorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static CursorType cursorType;

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
}
