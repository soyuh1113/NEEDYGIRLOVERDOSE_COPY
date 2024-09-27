using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicTest2 : MonoBehaviour
{
    public Button mainButton;
    public Button unlockButton;

    private bool event0ccurred = false;
    private int stat = 0;

    private void Start()
    {
        unlockButton.interactable = false;

        mainButton.onClick.AddListener(OnMainButtonClick);
    }

    public void OnMainButtonClick()
    {
        if (!event0ccurred)
        {
            stat += 1;
            Debug.Log(stat);
        }
        else
        {
            UnlockButton();
        }
    }

    public void OnEventOccur()
    {
        event0ccurred = true;
        Debug.Log("이벤트 발생");
    }

    private void UnlockButton()
    {
        unlockButton.interactable = true;
        Debug.Log("버튼 해금");
    }
}
