using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicTest : MonoBehaviour
{
    public Button[] stageButtons;

    void Start()
    {
        UnlockStages();
    }

    void UnlockStages()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            int stageUnlocked = PlayerPrefs.GetInt("Stage" + (i + 1), 0);

            if (stageUnlocked == 1)
            {
                stageButtons[i].interactable = true;
            }
            else
            {
                stageButtons[i].interactable = false;
            }
        }
    }

    public void OpenSpecificStage(int stageToOpen)
    {
        PlayerPrefs.SetInt("Stage" + stageToOpen, 1);
        PlayerPrefs.Save();
        UnlockStages();
    }

    public void OnButtonClick(int stageToOpen)
    {
        OpenSpecificStage(stageToOpen);
    }

    public void Clear()
    {
        PlayerPrefs.DeleteAll();

        UnlockStages();
    }

    public void evolution()
    {

    }
}
