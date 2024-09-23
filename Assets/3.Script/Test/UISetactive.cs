using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetactive : MonoBehaviour
{
    [SerializeField] private GameObject[] uiPrefab;
    [SerializeField] private GameObject btnPrefab;
    [SerializeField] private GameObject uiZone;
    [SerializeField] private GameObject uiBtnZone;
    
    [SerializeField] private TestBtnGruop layoutScript;

    private Vector2 uiPos;  //어떤 ui냐에 따라 다름
    private Vector2 btnPos;   //-85,0

    public void BtnClick(int uiNum)
    {
        GameObject clone = Instantiate(uiPrefab[uiNum], uiZone.transform);
        RectTransform rectTransform = clone.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = uiPos;

        GameObject clone1 = Instantiate(btnPrefab, uiBtnZone.transform);
        RectTransform recttransform = clone1.GetComponent<RectTransform>();
        recttransform.anchoredPosition = btnPos;

        Button buttonComponent = clone1.GetComponent<Button>();
        if (buttonComponent != null)
        {
            GameObject targetImage = clone;

            buttonComponent.onClick.AddListener(() =>
            {
                targetImage.SetActive(!targetImage.activeSelf);
            });
        }

        layoutScript.SetLayoutDirty();
    }
}
