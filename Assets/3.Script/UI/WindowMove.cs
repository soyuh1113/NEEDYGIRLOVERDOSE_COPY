using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowMove : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Transform uiTarget;

    public Vector2 originPos;
    public Vector2 originMousePos;
    public Vector2 movePos;

    [SerializeField] private Sprite active_Img;
    [SerializeField] private Sprite inactive_Img;

    public CursorLockMode cursorLockMode;

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
        if (!WindowSize.resizing)
        {
            RectTransform uiRectTransform = uiTarget.GetComponent<RectTransform>();
            RectTransform parentRectTransform = uiTarget.parent.GetComponent<RectTransform>();

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

        if (Input.GetMouseButtonUp(0) || !gameObject.activeInHierarchy)
        {
            StopDrag();
        }
    }

    private void StopDrag()
    {
        Cursor.lockState = cursorLockMode;
    }

    public void UpdateChildImages()
    {
        if (uiTarget.parent != null)
        {
            Transform parentTransform = uiTarget.parent;

            if (parentTransform.childCount > 0)
            {
                Transform lastChild = parentTransform.transform.GetChild(parentTransform.transform.childCount - 1);

                for (int i = 0; i < parentTransform.transform.childCount; i++)
                {
                    Transform child = parentTransform.transform.GetChild(i);
                    Image childImage = child.GetComponent<Image>();

                    if (child.Equals(lastChild))
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
}