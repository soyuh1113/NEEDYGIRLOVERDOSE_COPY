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

    [SerializeField] private Sprite active_Img;
    [SerializeField] private Sprite inactive_Img;

    //private bool isResizedToParent = false;

    private CursorLockMode cursorLockMode;

    public void OnPointerDown(PointerEventData eventData)
    {
        cursorLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Confined;

        originPos = uiTarget.position;
        originMousePos = eventData.position;

        uiTarget.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
       RectTransform uiRectTransform = uiTarget.GetComponent<RectTransform>();
       RectTransform parentRectTransform = uiTarget.parent.GetComponent<RectTransform>();

        if (!CursorController.resizing)
        {
            movePos = eventData.position - originMousePos;
            Vector2 newPosition = originPos + movePos;

            uiRectTransform.SetAsLastSibling();
            UpdateChildImages();

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

            uiTarget.position = newPosition;
        }
        else if(CursorController.resizing)
        {
            Vector2 dragAmount = eventData.position - originMousePos;
            Vector2 newSize = uiRectTransform.sizeDelta;

            switch (CursorController.cursorType)
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

            originMousePos = eventData.position;

            ClampToParent(uiRectTransform, parentRectTransform);
        }

        if (Input.GetMouseButtonUp(0) || !gameObject.activeInHierarchy)
        {
            StopDrag();
        }
    }

    private void StopDrag()
    {
        Cursor.lockState = cursorLockMode;
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

    public void UpdateChildImages()
    {
        if (uiTarget.parent != null)
        {
            Transform parentTransform = uiTarget.parent;

            if (parentTransform.childCount > 0)
            {
                Transform lastChild = parentTransform.transform.GetChild(parentTransform.transform.childCount - 1);

                for(int i = 0; i < parentTransform.transform.childCount; i++)
                {
                    Transform child = parentTransform.transform.GetChild(i);
                    Image childImage = child.GetComponent<Image>();

                    if (child == lastChild)
                    {
                        childImage.sprite = active_Img;
                    }
                    else
                    {
                        childImage.sprite = inactive_Img;
                    }
                }
            }
        }
    }

    public void ResizeToParent()
    {

    }
}
