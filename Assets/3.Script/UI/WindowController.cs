using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [Header("¿Ãµø«“ UI")]
    [SerializeField] private Transform moveUITarget;
    [SerializeField] private RectTransform uiTarget;

    //private Vector2 originalSize;
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

       // originalSize = uiTarget.sizeDelta;
        originPos = moveUITarget.position;
        originMousePos = eventData.position;

        moveUITarget.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        movedPos = eventData.position - originMousePos;
        Vector2 newPosition = originPos + movedPos;

        RectTransform parentRectTransform = uiTarget.parent.GetComponent<RectTransform>();
        RectTransform uiRectTransform = uiTarget.GetComponent<RectTransform>();

        Vector3[] parentCorners = new Vector3[4];
        parentRectTransform.GetWorldCorners(parentCorners);

        Vector3[] uiCorners = new Vector3[4];
        uiRectTransform.GetWorldCorners(uiCorners);

        float minX = parentCorners[0].x + (uiRectTransform.rect.width * uiTarget.lossyScale.x) / 2;
        float maxX = parentCorners[2].x - (uiRectTransform.rect.width * uiTarget.lossyScale.x) / 2;

        float minY = parentCorners[0].y + (uiRectTransform.rect.height * uiTarget.lossyScale.y) / 2;
        float maxY = parentCorners[2].y - (uiRectTransform.rect.height * uiTarget.lossyScale.y) / 2;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            
        moveUITarget.position = newPosition;

        if (Input.GetMouseButtonUp(0) || !gameObject.activeInHierarchy)
        {
            StopDrag();
        }
            

       // Vector2 mouseDelta = eventData.position - originMousePos;
       // uiTarget.sizeDelta = new Vector2(originalSize.x + mouseDelta.x, originalSize.y + mouseDelta.y);
    }
}
