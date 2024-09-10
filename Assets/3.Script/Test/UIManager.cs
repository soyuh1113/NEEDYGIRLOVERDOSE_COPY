using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiZone;
    [SerializeField] private GameObject uiBtnZone;

    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private Vector2 uiPrefabPos;

    [SerializeField] private GameObject btnPrefab;
    [SerializeField] private Vector2 btnPos;

    //private int objectSpawnCount = 1;

    public void Btn_Click()
    {
        GameObject clone = Instantiate(uiPrefab, uiZone.transform);
        RectTransform rectTransform = clone.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = uiPrefabPos;

        GameObject btn = Instantiate(btnPrefab, uiBtnZone.transform);
        RectTransform recttransform = btn.GetComponent<RectTransform>();
        recttransform.anchoredPosition = btnPos;
    }    
}