using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [Header("¿Ãµø«“ UI")]
    [SerializeField] private Transform moveUITarget;
    [SerializeField] private RectTransform uiTarget;

    private Vector2 originalSize;
    private Vector2 originPos;
    private Vector2 originMousePos;
    private Vector2 movedPos;

    private CursorLockMode cursorLockMode;

    private void StopDrag()
    {
        Cursor.lockState = cursorLockMode;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        cursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Confined;

        originalSize = uiTarget.sizeDelta;
        originPos = moveUITarget.position;
        originMousePos = eventData.position;

        moveUITarget.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        movedPos = eventData.position - originMousePos;
        moveUITarget.position = originPos + movedPos;

        if (Input.GetMouseButtonUp(0) || !gameObject.activeInHierarchy)
            StopDrag();

        Vector2 mouseDelta = eventData.position - originMousePos;
        uiTarget.sizeDelta = new Vector2(originalSize.x + mouseDelta.x, originalSize.y + mouseDelta.y);
    }
}
