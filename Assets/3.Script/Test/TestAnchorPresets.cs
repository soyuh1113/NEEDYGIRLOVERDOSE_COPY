using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnchorPresets : MonoBehaviour
{
    void Start()
    {
        //스크립트로 앵커 프리셋 수정
        RectTransform myRectTransform;
        myRectTransform = transform as RectTransform;
        myRectTransform.SetAnchor(AnchorPresets.StretchAll);
    }
}
