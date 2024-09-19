using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetactive : MonoBehaviour
{
    [SerializeField] private GameObject uiZone;
    [SerializeField] private GameObject uiBtnZone;
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private GameObject btnPrefab;
    [SerializeField] private TestBtnGruop layoutScript;

    private Vector2 uiPos;  //어떤 ui냐에 따라 다름
    private Vector2 btnPos;   //-85,0

    public void BtnClick()
    {
        GameObject clone = Instantiate(uiPrefab, uiZone.transform);
        RectTransform rectTransform = clone.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = uiPos;

        GameObject clone1 = Instantiate(btnPrefab, uiBtnZone.transform);
        RectTransform recttransform = clone1.GetComponent<RectTransform>();
        recttransform.anchoredPosition = btnPos;

        layoutScript.SetLayoutDirty();
    }

    public void UIActive()
    {
        
    }

}
