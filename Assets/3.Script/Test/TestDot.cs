using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TestDot : MonoBehaviour
{
    public Ease ease;
    public int targetX;
    public int targetY;

    public int targetScale;

    public Color targetColor;

    public TextMeshProUGUI text;
    public int targetFadeValue = 0;

    public TextMeshProUGUI text2;
    public string textString;

    private void Start()
    {
        //transform.DOMoveX(targetX, 3);  //�̵�

        //transform.DORotate(new Vector2(0, -90), 3);   //ȸ��

        //transform.DOShakeRotation(3);   //����

        //transform.DOScale(targetScale, 3).SetEase(ease);    //ũ��(?)

        //transform.GetComponent<Renderer>().material.DOColor(targetColor, 3);    //����

        //text.DOFade(targetFadeValue, 3);    //���� �� ����

        //text2.DOText(textString, 3);

        //transform.DOMoveY(targetX, 3).SetEase(ease);
    }
    
    public void TestBtn()
    {
        //transform.DOMove(targetY, 5);
    }




}
