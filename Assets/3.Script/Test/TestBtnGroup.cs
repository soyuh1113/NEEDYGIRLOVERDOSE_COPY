using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBtnGroup : MonoBehaviour
{
    public Vector2 newSize = new Vector2(100, 100);

    public void Size()
    {
        foreach (RectTransform child in transform)
        {
            child.sizeDelta = newSize;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

}
