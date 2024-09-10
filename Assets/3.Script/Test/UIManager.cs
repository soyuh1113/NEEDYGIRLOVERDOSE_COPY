using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private Vector2 uiPrefabPos;

    [SerializeField] private GameObject togglePrefab;

    //private int objectSpawnCount = 1;

    public void Btn_Click()
    {
        GameObject clone = Instantiate(uiPrefab, GameObject.Find("Window_Canvas/UIZone").transform);
        RectTransform rectTransform = clone.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = uiPrefabPos;
    }    
}