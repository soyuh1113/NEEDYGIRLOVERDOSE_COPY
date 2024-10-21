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

        if (childCount == 4) return;

        float availableWidth = parentRect.rect.width - spacing * (childCount - 1);
        float buttonWidth = availableWidth / childCount;

        float currentX = 0f;

        for (int i = 0; i < childCount; i++)
        {
            RectTransform child = parentRect.GetChild(i) as RectTransform;
            if (child == null) continue;

            child.sizeDelta = new Vector2(buttonWidth, child.sizeDelta.y);

            child.anchoredPosition = new Vector2(currentX, 0);
            currentX += buttonWidth + spacing;
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