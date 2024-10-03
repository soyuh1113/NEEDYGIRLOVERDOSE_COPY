using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            ChatData chatData = JsonUtility.FromJson<ChatData>(jsonFile.text);

            foreach(Chat chat in chatData.chat)
            {
                if(chat.Lines != null)
                {
                    foreach(Line line in chat.Lines)
                    {
                        dialogues.Add(line.line);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("JSON ������ ã�� �� �����ϴ�!");
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
                Debug.LogError("��ư�� Text ������Ʈ�� �����ϴ�!");
            }
        }
    }
}
