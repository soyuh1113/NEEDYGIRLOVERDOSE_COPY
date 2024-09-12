using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBtnGruop : MonoBehaviour
{
    [SerializeField] private GameObject uiZone;
    [SerializeField] private GameObject uiBtnZone;

    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private Vector2 uiPrefabPos;

    [SerializeField] private GameObject btnPrefab;
    [SerializeField] private Vector2 btnPos;

    public RectTransform parentRect;
    //private float spacing = 10f;

    //private float buttonWidth = 100f;
    //private float buttonHeight = 50f;
   //private float minButtonWidth = 50f;
   //private float maxButtonWidth = 150f;

    public void BtnClick()
    {
        GameObject clone = Instantiate(uiPrefab, uiZone.transform);
        RectTransform rectTransform = clone.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = uiPrefabPos;

        GameObject btn = Instantiate(btnPrefab, uiBtnZone.transform);
        RectTransform recttransform = btn.GetComponent<RectTransform>();
        recttransform.anchoredPosition = btnPos;

        //recttransform.sizeDelta = new Vector2(buttonWidth, buttonHeight);
        //
        //Text buttonText = btn.GetComponentInChildren<Text>();
        //buttonText.text = "This is a long text";
        //buttonText.GetComponent<TextData>().originalText = buttonText.text;
        //
        //AdjustTextToFit(buttonText, buttonWidth);
    }

   //void AdjustTextToFit(Text text, float buttonWidth)
   //{
   //    string originalText = text.GetComponent<TextData>().originalText; // 원본 텍스트 가져오기
   //    TextGenerator textGen = new TextGenerator();
   //    TextGenerationSettings settings = text.GetGenerationSettings(Vector2.zero);
   //
   //    if (textGen.GetPreferredWidth(originalText, settings) > buttonWidth)
   //    {
   //        int charsToShow = originalText.Length;
   //        while (charsToShow > 0 && textGen.GetPreferredWidth(originalText.Substring(0, charsToShow) + "...", settings) > buttonWidth)
   //        {
   //            charsToShow--;
   //        }
   //
   //        text.text = originalText.Substring(0, charsToShow) + "...";
   //    }
   //    else
   //    {
   //        text.text = originalText;
   //    }
   //}
   //
   //public void ResizeButton(GameObject button, float newWidth)
   //{
   //    RectTransform buttonRect = button.GetComponent<RectTransform>();
   //    buttonRect.sizeDelta = new Vector2(newWidth, buttonRect.sizeDelta.y);
   //
   //    Text buttonText = button.GetComponentInChildren<Text>();
   //    AdjustTextToFit(buttonText, newWidth);
   //}
}

public class TextData : MonoBehaviour
{
    public string originalText;
}
