using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnchorPresets : MonoBehaviour
{
    void Start()
    {
        //��ũ��Ʈ�� ��Ŀ ������ ����
        RectTransform myRectTransform;
        myRectTransform = transform as RectTransform;
        myRectTransform.SetAnchor(AnchorPresets.StretchAll);
    }
}
