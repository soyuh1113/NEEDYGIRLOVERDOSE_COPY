using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestWindow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Transform moveUITarget;

    public Sprite imageA;
    public Sprite imageB;

    private Vector2 originPos;
    private Vector2 originMousePos;
    private Vector2 movedPos;

    private Vector2 originalSize;
    private bool isResizedToParent = false;

    private CursorLockMode cursorLockMode;

    private void StopDrag()
    {
        Cursor.lockState = cursorLockMode;
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
        if (!TestCursor.resizing)
        {
            movedPos = eventData.position - originMousePos;
            Vector2 newPosition = originPos + movedPos;

            RectTransform parentRectTransform = moveUITarget.parent.GetComponent<RectTransform>();
            RectTransform uiRectTransform = moveUITarget.GetComponent<RectTransform>();

            uiRectTransform.SetAsLastSibling();
            UpdateChildImages();

            Vector3[] parentCorners = new Vector3[4];
            parentRectTransform.GetWorldCorners(parentCorners);

            Vector3[] uiCorners = new Vector3[4];
            uiRectTransform.GetWorldCorners(uiCorners);

            float minX = parentCorners[0].x + (uiRectTransform.rect.width * moveUITarget.lossyScale.x) / 2;
            float maxX = parentCorners[2].x - (uiRectTransform.rect.width * moveUITarget.lossyScale.x) / 2;

            float minY = parentCorners[0].y + (uiRectTransform.rect.height * moveUITarget.lossyScale.y) / 2;
            float maxY = parentCorners[2].y - (uiRectTransform.rect.height * moveUITarget.lossyScale.y) / 2;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            moveUITarget.position = newPosition;
        }

        if (Input.GetMouseButtonUp(0) || !gameObject.activeInHierarchy)
        {
            StopDrag();
        }
    }

    public void ResizeToParent()
    {
        RectTransform parentRectTransform = moveUITarget.parent.GetComponent<RectTransform>();
        RectTransform uiRectTransform = moveUITarget.GetComponent<RectTransform>();

        if (!isResizedToParent)
        {
            originalSize = uiRectTransform.sizeDelta;

            RectTransform myRectTransform;
            myRectTransform = transform as RectTransform;
            myRectTransform.SetAnchor(AnchorPresets.StretchAll);

            //uiRectTransform.sizeDelta = new Vector2(parentRectTransform.rect.width, parentRectTransform.rect.height);
            isResizedToParent = true;
        }
        else
        {
            RectTransform myRectTransform;
            myRectTransform = transform as RectTransform;
            myRectTransform.SetAnchor(AnchorPresets.MiddleCenter);

            uiRectTransform.sizeDelta = originalSize;
            isResizedToParent = false;
        }
    }

    public void UpdateChildImages()
    {
        if (moveUITarget.parent != null)
        {
            Transform parentTransform = moveUITarget.parent;

            if (parentTransform.childCount > 0)
            {
                Transform lastChild = parentTransform.transform.GetChild(parentTransform.transform.childCount - 1);

                for (int i = 0; i < parentTransform.transform.childCount; i++)
                {
                    Transform child = parentTransform.transform.GetChild(i);
                    Image childImage = child.GetComponent<Image>();

                    if (child == lastChild)
                    {
                        childImage.sprite = imageA;
                    }
                    else
                    {
                        childImage.sprite = imageB;
                    }
                }
            } 
        }
    }
}