using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public string jsonFileName = "TestLive";

    public GameObject buttonPrefab;

    public Transform buttonContainer;

    private List<string> dialogues = new List<string>();

    void Start()
    {
        LoadDialogueFromJSON();
        CreateDialogueButtons();
    }
    void LoadDialogueFromJSON()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

        if (jsonFile != null)
        {
            TestChat dialogueData = JsonUtility.FromJson<TestChat>(jsonFile.text);
            dialogues = dialogueData.chats;
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다!");
        }
    }

    void CreateDialogueButtons()
    {
        foreach (string dialogue in dialogues)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);

            Text buttonText = newButton.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = dialogue;
            }
            else
            {
                Debug.LogError("버튼에 Text 컴포넌트가 없습니다!");
            }
        }
    }
}
