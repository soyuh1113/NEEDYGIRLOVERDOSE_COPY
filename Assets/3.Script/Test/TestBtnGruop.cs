using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TestBtnGruop : MonoBehaviour
{
    [SerializeField] private float spacing = 5f;
    //[SerializeField] private bool autoResize = true;
    [SerializeField] private bool layoutDirty = true;

    private void Start()
    {
        LayoutElements();
    }

    private void Update()
    {
        if (layoutDirty)
        {
            LayoutElements();
            layoutDirty = false;
        }
    }

    public void SetLayoutDirty()
    {
        layoutDirty = true;
    }

    public void LayoutElements()
    {
        RectTransform parentRect = GetComponent<RectTransform>();
        int childCount = parentRect.childCount;

        if (childCount == 0) return;

        float totalWidth = 0f;

        for (int i = 0; i < childCount; i++)
        {
            RectTransform child = parentRect.GetChild(i) as RectTransform;
            if (child == null) continue;

            totalWidth += child.sizeDelta.x + spacing;
        }

        if (totalWidth > parentRect.rect.width)
        {
            float scaleFactor = (parentRect.rect.width - spacing * (childCount - 1)) / (totalWidth - spacing * (childCount - 1));

            for (int i = 0; i < childCount; i++)
            {
                RectTransform child = parentRect.GetChild(i) as RectTransform;
                if (child == null) continue;

                Vector2 originalSize = child.sizeDelta;
                child.sizeDelta = new Vector2(originalSize.x * scaleFactor, originalSize.y);

                if (i == 0)
                {
                    child.anchoredPosition = new Vector2(0, 0);
                }
                else
                {
                    RectTransform previousChild = parentRect.GetChild(i - 1) as RectTransform;
                    child.anchoredPosition = new Vector2(previousChild.anchoredPosition.x + previousChild.sizeDelta.x + spacing, 0);
                }
            }
        }
        else
        {
            float currentX = 0f;
            for (int i = 0; i < childCount; i++)
            {
                RectTransform child = parentRect.GetChild(i) as RectTransform;
                if (child == null) continue;

                child.anchoredPosition = new Vector2(currentX, 0);
                currentX += child.sizeDelta.x + spacing;
            }
        }
    }

    public void AddButton(GameObject buttonPrefab)
    {
        GameObject newButton = Instantiate(buttonPrefab, transform);
        SetLayoutDirty();
    }

    public void RemoveButton(GameObject button)
    {
        Destroy(button);
        SetLayoutDirty();
    }
}