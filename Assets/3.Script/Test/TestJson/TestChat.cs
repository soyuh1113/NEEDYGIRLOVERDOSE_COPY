using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line
{
    public string line;
}

[System.Serializable]
public class Chat
{
    public int id;
    public List<Line> Lines;
}

[System.Serializable]
public class ChatData
{
    public List<Chat> chat;
}
