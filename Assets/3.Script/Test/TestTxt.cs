using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestTxt : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject webcamUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Ŀ��");
        webcamUI.transform.position = Vector2.zero;
        RectTransform uiRect = webcamUI.GetComponent<RectTransform>();
        uiRect.anchoredPosition = webcamUI.transform.position;
        //uiRect.   //ũ�⺯��
        //webcamUI.GetComponent<RectTransform>().anchoredPosition
    }
}
