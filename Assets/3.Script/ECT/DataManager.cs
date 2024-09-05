using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    int id;
    string character;
    string text;
}

[Serializable]
public class StatData
{
    public List<Stats> stats = new List<Stats>();
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Instance = null;
        }
    }

    private void Start()
    {
        TextAsset Text = Resources.Load<TextAsset>("Test");
        StatData data = JsonUtility.FromJson<StatData>(Text.text);
    }
}
