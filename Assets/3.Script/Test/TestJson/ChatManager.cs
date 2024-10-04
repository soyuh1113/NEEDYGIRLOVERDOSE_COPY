using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public string jsonFileName = "Live";

    public GameObject buttonPrefab;

    public Transform buttonContainer;

    public TextMeshProUGUI additionalTextObject;

    private List<Chat> chatList = new List<Chat>();

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
            chatList = chatData.chat;
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다!");
        }
    }

    void CreateDialogueButtons()
    {
        foreach (Chat chat in chatList)
        {
            foreach(Line line in chat.Lines)
            {
                GameObject newButton = Instantiate(buttonPrefab, buttonContainer);

                TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    if (chat.id == 1)
                    {
                        buttonText.text = "[ID 1]" + line.line;
                    }
                    else if (chat.id == 2)
                    {
                        buttonText.text = "[ID 2]" + line.line;
                    }
                }
                else
                {
                    Debug.LogError("버튼에 Text 컴포넌트가 없습니다!");
                }

                Button buttonComponent = newButton.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => ClearButtonText(buttonText));
                }
                else
                {
                    Debug.LogError("버튼에 Button 컴포넌트가 없습니다!");
                }
            }
        }
    }

    private void ClearButtonText(TextMeshProUGUI buttonText)
    {
        if(buttonText.text== "꺼져")
        {
            if (additionalTextObject != null)
            {
                additionalTextObject.text += buttonText.text + "\n";
            }
        }
        else
        {
            buttonText.text = "";
        }
    }
}
